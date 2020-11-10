using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BucketOOP.Buckets
{
    public static class MathExt
    {
        public static T Clamp<T>( this T value, T min, T max ) where T: IComparable
        {
            if ( value.CompareTo(min) < 0 )
            {
                return min;
            }

            if ( value.CompareTo(max) > 0 )
            {
                return max;
            }

            return value;
        }
    }
}
