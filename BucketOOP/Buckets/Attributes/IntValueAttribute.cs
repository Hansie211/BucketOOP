using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Buckets.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false )]
    public class IntValueAttribute : Attribute
    {
        public int Value { get; }

        public IntValueAttribute( int value )
        {
            Value = value;
        }
    }
}
