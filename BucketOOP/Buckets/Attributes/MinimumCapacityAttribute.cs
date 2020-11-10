using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Buckets.Attributes
{
    public class MinimumCapacityAttribute : IntValueAttribute
    {
        public MinimumCapacityAttribute( int value ) : base( value )
        {
        }
    }
}
