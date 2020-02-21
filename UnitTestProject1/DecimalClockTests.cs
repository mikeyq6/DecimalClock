using System;
using DecimalClockLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class DecimalClockTests
    {
        [TestMethod]
        public void TestDate_AreCorrect()
        {
            // Arrange
            DateTime dt1 = new DateTime(1798, 9, 22, 10, 30, 0);
            DateTime dt2 = new DateTime(1798, 5, 22, 10, 30, 0);

            // Act
            DecimalDateTime ddt1 = new DecimalDateTime(dt1);
            DecimalDateTime ddt2 = new DecimalDateTime(dt2);
            string expected1 = "1 Vendémiaire VII";
            string expected2 = "3 Prairial VI";

            // Assert 
            Assert.AreEqual(expected1, ddt1.DateString(), "Dates are not equal");
            Assert.AreEqual(expected2, ddt2.DateString(), "Dates are not equal");
        }
    }
}
