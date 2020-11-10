using BucketOOP.Buckets.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Buckets
{
    [DefaultCapacity( 12 ), MinimumCapacity( 10 )]
    public class Bucket : BucketBase
    {
        public Bucket() : base()
        {
        }

        public Bucket( int content ) : base( content )
        {
        }

        public Bucket( int content, int capacity ) : base( content, capacity )
        {
        }

        public void Fill( Bucket bucket )
        {
            int contentLeft = Fill( bucket.Content );
            bucket.Empty( bucket.Content - contentLeft );
        }
    }
}
