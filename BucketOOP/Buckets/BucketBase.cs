using System;
using System.Diagnostics;
using System.Reflection;
using BucketOOP.Buckets.Attributes;
using BucketOOP.Buckets.EventsArguments;

namespace BucketOOP.Buckets
{
    [ DefaultContent( 0 ), MinimumContent( 0 ), MinimumCapacity( 0 ) ]
    public abstract class BucketBase
    {
        public static readonly int MIN_CONTENT = 0;

        private int content;
        public int Content
        {
            get => content;
            set {
                Fill( value );
            }
        }
        public int Capacity { get; }

        public event EventHandler<OverflowingEventArgs> OnOverflowing;
        public event EventHandler<OverflowedEventArgs> OnOverflowed;
        public event EventHandler OnFull;
        public event EventHandler OnEmpty;

        public BucketBase() : this( null, null )
        {
        }

        public BucketBase( int content ) : this( content, null )
        {

        }

        public BucketBase( int content, int capacity ) : this( (int?)content, (int?)capacity )
        {
        }

        private BucketBase( int? content, int? capacity )
        {
            capacity = capacity ?? GetAttributeValue<DefaultCapacityAttribute>();
            content  = content ?? GetAttributeValue<DefaultContentAttribute>();

            Capacity = capacity.Value;
            Content  = content.Value.Clamp( GetAttributeValue<MinimumContentAttribute>(), capacity.Value );
        }

        private int GetAttributeValue<TAttr>() where TAttr : IntValueAttribute
        {
            var attribute = this.GetType().GetCustomAttribute<TAttr>( true );
            return attribute?.Value ?? 0;
        }

        public int Fill( int amount )
        {
            int originalAmount = amount;
            Debug.WriteLine( $"Fill bucket with { Content }L by { amount }L." );
            if ( amount <= 0 )
            {
                return 0;
            }

            int overflowAmount = content + amount - Capacity;
            if ( overflowAmount > 0 )
            {
                var eventArgs = new OverflowingEventArgs( amount, Capacity - content );
                OnOverflowing?.Invoke( this, eventArgs );

                if ( eventArgs.AmountToAdd <= 0 )
                {
                    return 0;
                }

                amount          = Math.Min( eventArgs.AmountToAdd, amount );
                overflowAmount  = content + amount - Capacity;
            }

            content = Math.Min( content + amount, Capacity );
            if ( Content < Capacity )
            {
                return originalAmount - amount;
            }

            OnFull?.Invoke( this, EventArgs.Empty );

            if ( Content == Capacity )
            {
                return originalAmount - amount;
            }

            OnOverflowed?.Invoke( this, new OverflowedEventArgs( originalAmount, amount, overflowAmount ) );
            return originalAmount - amount;
        }

        public void Empty( int amount )
        {
            Debug.WriteLine( $"Empty bucket with { Content }L by { amount }L." );

            if ( amount <= 0 )
            {
                return;
            }

            amount  = Math.Min( amount, Content );
            content -= amount;

            if ( Content == MIN_CONTENT )
            {
                OnEmpty?.Invoke( this, EventArgs.Empty );
            }
        }

        public void Empty()
        {
            Empty( Content );
        }
    }
}
