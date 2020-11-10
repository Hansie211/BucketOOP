using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Buckets.EventsArguments
{
    public class OverflowedEventArgs : EventArgs
    {
        public int InitialAmount { get; }
        public int ActualAmount { get; }
        public int AmountOverflowed { get; }

        public OverflowedEventArgs( int initialAmount, int actualAmount, int amountOverflowed )
        {
            InitialAmount       = initialAmount;
            ActualAmount        = actualAmount;
            AmountOverflowed    = amountOverflowed;
        }
    }
}
