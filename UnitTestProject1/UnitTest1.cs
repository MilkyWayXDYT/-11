using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ЛР11;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Double[] myAr = { 2, 3, 4, 5 };
            Double[] myAr2 = { 3, 4, 5, 6 };

            Double expected = 26.0/42.0;

            Double actual = ProcessingArray.Main(myAr, myAr2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod2()
        {
            Double[] myAr = { 0, 0, 0, 0 };
            Double[] myAr2 = { 0, 0, 0, 0 };

            Double actual = ProcessingArray.Main(myAr, myAr2);
        }
    }
}
