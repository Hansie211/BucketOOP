using BucketOOP.Buckets;
using System;

namespace BucketOOP
{
    class Program
    {
        static bool DoCancelOverflow = true;

        static void Main( string[] args )
        {
            Bucket bucket = new Bucket();
            bucket.Content = bucket.Capacity + 10;

            //bucket.OnFull           += Bucket_OnFull;
            //bucket.OnOverflowing    += Bucket_OnOverflowing;
            //bucket.OnOverflowed     += Bucket_OnOverflowed;

            bucket.Fill( 10 );
            bucket.Fill( 3 );

            Console.WriteLine(); // Empty line

            DoCancelOverflow = false;
            bucket.Fill( 5 );

            bucket.Empty();
        }

        private static void Bucket_OnOverflowed( object sender, int amount )
        {
            Console.WriteLine( $"Bucket overflowed by { amount }." );
        }

        private static void Bucket_OnOverflowing( object sender, int amount, ref bool cancel )
        {
            if ( DoCancelOverflow )
            {
                cancel = true;
            }

            Console.WriteLine( $"Overflowing by { amount } (cancel: { cancel })." );
        }

        private static void Bucket_OnFull( object sender )
        {
            Console.WriteLine( "Bucket is full" );
        }

    }
}
