using BucketOOP.Buckets;
using System;

namespace BucketOOP
{
    class Program
    {
        static void Main( string[] args )
        {
            Bucket bucket = new Bucket();

            bucket.Fill( 10 );
            bucket.Fill( 3 );

            bucket.Empty();
        }
    }
}
