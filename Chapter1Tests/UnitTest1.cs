using Chapter1;
using NUnit.Framework;

namespace Chapter1Tests
{
    
    [TestFixture]
    public class ConvertBaseTests
    {
        [Test]
        public void TestBase10ToBase2()
        {
            var r = ConvertBase.ConvertBaseString("1234", 10, 2);
            Assert.AreEqual("10011010010", r);
        }

        [Test]
        public void TestBase2ToBase10()
        {
            var r = ConvertBase.ConvertBaseString("1001110101", 2, 10);
            Assert.AreEqual("629", r);
        }

        [Test]
        public void TestBase2ToBase16()
        {
            var r = ConvertBase.ConvertBaseString("1001110101", 2, 16);
            Assert.AreEqual("275", r);
        }

        [Test]
        public void TestBase2ToBase16_Letters()
        {
            var r = ConvertBase.ConvertBaseString("101010110001001000111011", 2, 16);
            Assert.AreEqual("AB123B", r);
        }

        [Test]
        public void TestBase16ToBase8()
        {
            var r = ConvertBase.ConvertBaseString("AB123B", 16, 8);
            Assert.AreEqual("52611073", r);
        }
    }

    [TestFixture]
    public class FloatOperationsTests{

        [Test]
        public void TestFromFloatWholeNumber()
        {
            const float expected = 181819f;
            var fl = FloatOperations.FromFloat(expected);
            Assert.AreEqual(expected, fl.ToDecimal());
        }

        [Test]
        public void TestFromFloatDecimalNumber()
        {
            const float expected = 18.000481f;
            var fl = FloatOperations.FromFloat(expected);
            Assert.AreEqual(expected, fl.ToDecimal());
        }

        [Test]
        public void TestFromFloatSubOneDecimal()
        {
            const float expected = 0.0013581f;
            var fl = FloatOperations.FromFloat(expected);
            Assert.AreEqual(expected, fl.ToDecimal());
        }
        
        [Test]
        public void TestFromFloatNegative()
        {
            const float expected = -1015f;
            var fl = FloatOperations.FromFloat(expected);
            Assert.AreEqual(expected, fl.ToDecimal());
        }

        [Test]
        public void TestFromFloatSubZeroDecimal()
        {
            const float expected = -1.007147101f;
            var fl = FloatOperations.FromFloat(expected);
            Assert.AreEqual(expected, fl.ToDecimal());
        }
    }
}