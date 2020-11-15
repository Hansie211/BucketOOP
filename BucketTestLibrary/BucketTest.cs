using BucketOOP.Buckets;
using BucketOOP.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BucketTestLibrary
{
    [TestClass]
    public class BucketTest
    {

        // Emmer aanmaken met parameters
        // Emmer aanmaken met lege constructor
        // Emmer vullen ( in gedeeltes )
        // Emmer vullen met andere emmer
        // Emmer legen ( in gedeeltes V in 1x )
        // Emmer standaard afmeting
        // Emmer minimale afmeting
        // Waarschuwing als emmer vol is
        // Olievat heeft altijd 159 als inhoud
        // Regenton kan alleen worden aangemaakt met 80,120,160
        // Olievat en regenton inherit van emmer
        // Waarschuwing als emmer gaat overstromen
        // Toe te voegen hoeveelheid aanpassen als de emmer gaat overstromen
        // Stoppen als emmer gaat overstromen

        [TestMethod]
        public void TestBucketConstructorParameters()
        {
            const int expectedContent  = 20;
            const int expectedCapacity = 25;

            var bucket = new Bucket( expectedContent, expectedCapacity );

            Assert.IsTrue( bucket.Capacity == expectedCapacity );
            Assert.IsTrue( bucket.Content == expectedContent );
        }

        [TestMethod]
        public void TestBucketDefaultConstructorParameters()
        {
            const int expectedContent   = 0;
            const int expectedCapacity  = 12;

            var bucket = new Bucket();

            Assert.IsTrue( bucket.Capacity == expectedCapacity );
            Assert.IsTrue( bucket.Content == expectedContent );
        }

        [TestMethod]
        public void TestBucketMinimumCapacity()
        {
            const int minimumCapacity = 10;

            var bucket = new Bucket( 0, minimumCapacity - 3 );

            Assert.IsTrue( bucket.Capacity == minimumCapacity );
        }

        [TestMethod]
        public void TestFill()
        {
            const int waterAmount = 5;

            var bucket = new Bucket();
            bucket.Fill( waterAmount );

            Assert.IsTrue( bucket.Content == waterAmount );
        }

        [TestMethod]
        public void TestFillWithBucket()
        {
            const int waterAmount = 5;

            var bucketA = new Bucket();
            var bucketB = new Bucket( waterAmount );

            bucketA.Fill( bucketB );

            Assert.IsTrue( bucketA.Content == waterAmount );
            Assert.IsTrue( bucketB.Content == 0 );
        }

        [TestMethod]
        public void TestEmpty()
        {
            const int amountInBucket = 10;
            const int amountToRemove = 6;
            const int expectedContent = amountInBucket - amountToRemove;

            var bucket = new Bucket( amountInBucket );
            bucket.Empty( amountToRemove );

            Assert.IsTrue( bucket.Content == expectedContent );
        }

        [TestMethod]
        public void TestCompleteEmpty()
        {
            const int amountInBucket  = 10;
            const int expectedContent = 0;

            var bucket = new Bucket( amountInBucket );
            bucket.Empty();

            Assert.IsTrue( bucket.Content == expectedContent );
        }

        [TestMethod]
        public void TestWarningOnFull()
        {
            const int capacity = 20;
            bool eventFired = false;

            var bucket = new Bucket( 0, capacity );
            bucket.OnFull += ( s, e ) => eventFired = true;
            bucket.Fill( capacity );

            Assert.IsTrue( eventFired );
        }

        [TestMethod]
        public void TestOilBarrelCapacity()
        {
            const int expectedCapacity = 159;

            var barrel = new OilBarrel();

            Assert.IsTrue( barrel.Capacity == expectedCapacity );
        }

        [TestMethod]
        public void TestRainBarrelCapacity()
        {
            #region Sub testmethod 'TestIsIllegal'
            System.Func<int, bool> TestIsIllegal = ( capacity ) => {
                try
                {
                    var barrel = new RainBarrel(0, (BucketOOP.Buckets.Enums.CapacityOption)capacity );
                }
                catch
                {
                    return true;
                }

                return false;
            };
            #endregion

            int[] allowedCapacities = new int[] { 80, 120, 160 };

            foreach ( var capacity in allowedCapacities )
            {
                Assert.IsFalse( TestIsIllegal( capacity ) );
            }

            Assert.IsTrue( TestIsIllegal( 0 ) );
        }

        [TestMethod]
        public void TestInheritance()
        {
            var bucket = new Bucket();
            var rainBarrel = new RainBarrel();
            var oilBarrel = new OilBarrel();

            Assert.IsTrue( bucket is BucketBase );
            Assert.IsTrue( rainBarrel is BucketBase );
            Assert.IsTrue( oilBarrel is BucketBase );
        }

        [TestMethod]
        public void TestWarningOverflowing()
        {
            const int capacity = 20;
            bool eventFired = false;

            var bucket = new Bucket();
            bucket.OnOverflowing += ( s, e ) => { eventFired = true; };
            bucket.Fill( capacity + 1 );

            Assert.IsTrue( eventFired );
        }

        [TestMethod]
        public void TestWarningOverflowed()
        {
            const int capacity = 20;
            bool eventFired = false;

            var bucket = new Bucket( 0, capacity );
            bucket.OnOverflowed += ( s, e ) => { eventFired = true; };
            bucket.Fill( capacity + 1 );

            Assert.IsTrue( eventFired );
        }

        [TestMethod]
        public void TestCancelOverflow()
        {
            const int capacity = 20;
            const int exepectedContent = 0;

            var bucket = new Bucket();
            bucket.OnOverflowing += ( s, e ) => { e.AmountToAdd = 0; };
            bucket.Fill( capacity + 1);

            Assert.IsTrue( bucket.Content == exepectedContent );
        }

        [TestMethod]
        public void TestOverflowAdjust()
        {
            const int capacity = 20;
            const int expectedContent = 5;

            var bucket = new Bucket();
            bucket.OnOverflowing += ( s, e ) => { e.AmountToAdd = expectedContent; };
            bucket.Fill( capacity + 1);

            Assert.IsTrue( bucket.Content == expectedContent );
        }

        [TestMethod]
        public void TestOverflowAdjustFill()
        {
            const int capacity = 20;
            const int expectedContent = capacity;

            var bucket = new Bucket( 0, capacity );
            bucket.OnOverflowing += ( s, e ) => { e.AmountToAdd = e.MaxAmount; };
            bucket.Fill( capacity + 1 );

            Assert.IsTrue( bucket.Content == expectedContent );
        }
    }
}
