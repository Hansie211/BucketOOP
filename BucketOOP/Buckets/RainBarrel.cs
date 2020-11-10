using BucketOOP.Buckets.Attributes;
using BucketOOP.Buckets.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Buckets
{
    [DefaultCapacity( (int)CapacityOption.Medium )]
    public partial class RainBarrel : BucketBase
    {
        public RainBarrel() : base()
        {
        }

        public RainBarrel( int content ) : base( content )
        {
        }

        public RainBarrel( int content, CapacityOption capacity ) : base( content, (int)capacity )
        {
        }
    }
}
