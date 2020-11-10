using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Buckets.EventsArguments
{
    public class OverflowingEventArgs : EventArgs
    {
        public int AmountToAdd { get; set; }
        public int MaxAmount { get; }

        public OverflowingEventArgs( int amountToAdd, int maxAmount  )
        {
            AmountToAdd = amountToAdd;
            MaxAmount   = maxAmount;
        }
    }
}
