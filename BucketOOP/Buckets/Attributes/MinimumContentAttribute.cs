using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Buckets.Attributes
{
    public class MinimumContentAttribute : IntValueAttribute
    {
        public MinimumContentAttribute( int value ) : base( value )
        {
        }
    }
}
