using BucketOOP.Buckets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BucketTestLibrary
{
    [TestClass]
    public class BucketTest
    {
        [TestMethod]
        public void TestFlow()
        {
            const int bucketCapacity    = 100;
            const int fillBucketAmount  = 90;

            var bucket = new Bucket(0, bucketCapacity);

            int amountLeft = bucket.Fill( fillBucketAmount );

            Assert.IsTrue( amountLeft == 0 );
            Assert.IsTrue( bucket.Content == fillBucketAmount );
        }

        [TestMethod]
        public void TestOverflow()
        {
            const int bucketCapacity    = 100;
            const int fillBucketAmount  = 100 + 10;

            var bucket = new Bucket(0, bucketCapacity);

            int amountLeft = bucket.Fill( fillBucketAmount );

            Assert.IsTrue( amountLeft == 0 );
            Assert.IsFalse( bucket.Content == fillBucketAmount );
        }

        [TestMethod]
        public void TestCancelOverflow()
        {
            const int bucketCapacity    = 100;
            const int fillBucketAmount  = 100 + 10;

            var bucket = new Bucket(0, bucketCapacity);
            bucket.OnOverflowing += ( s, e ) => {
                e.AmountToAdd = e.MaxAmount;
            };

            int amountLeft = bucket.Fill( fillBucketAmount );

            Assert.IsTrue( amountLeft == 10 );
            Assert.IsFalse( bucket.Content == fillBucketAmount );
        }

        [TestMethod]
        public void TestClamp()
        {
            const int x = 10;

            Assert.IsTrue( x.Clamp( 0, 100 ) == x );

            Assert.IsTrue( x.Clamp( x, 100 ) == x );
            Assert.IsTrue( x.Clamp( x + 1, 100 ) == x + 1 );

            Assert.IsTrue( x.Clamp( 0, x ) == x );
            Assert.IsTrue( x.Clamp( 0, x - 1 ) == x - 1 );
        }
    }
}
