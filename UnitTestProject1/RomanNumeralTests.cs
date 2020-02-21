using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecimalClockLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class RomanNumeralTests
    {
        [TestMethod]
        public void RomanNumber_TestRegulars()
        {
            // Arrange
            int[] numbers = { 5, 2, 600, 1300, 1355, 1788, 2001 };
            string[] expected = { "V", "II", "DC", "MCCC", "MCCCLV", "MDCCLXXXVIII", "MMI" };

            // Act 
            // Assert
            int i = 0;
            foreach(int number in numbers)
            {
                string result = RomanNumeral.GetRomanValue((uint)number);
                Assert.AreEqual(expected[i], result, "Results are not equal");
                i++;
            }
        }
        [TestMethod]
        public void RomanNumber_TestEdges()
        {
            // Arrange
            int[] numbers = { 4, 9, 40, 98, 999, 1982, 1949 };
            string[] expected = { "IV", "IX", "XL", "XCVIII", "CMXCIX", "MCMLXXXII", "MCMXLIX" };

            // Act 
            // Assert
            int i = 0;
            foreach (int number in numbers)
            {
                string result = RomanNumeral.GetRomanValue((uint)number);
                Assert.AreEqual(expected[i], result, "Results are not equal");
                i++;
            }
        }
    }
}
