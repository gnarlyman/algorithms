using Chapter1;
using NUnit.Framework;

namespace Chapter1Tests
{
    public class Tests
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
}