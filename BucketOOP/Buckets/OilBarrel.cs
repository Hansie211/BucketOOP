using BucketOOP.Buckets.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Buckets
{
    [DefaultCapacity( 159 )]
    public class OilBarrel : BucketBase
    {
        public OilBarrel() : base()
        {
        }

        public OilBarrel( int content ) : base( content )
        {
        }
    }
}
