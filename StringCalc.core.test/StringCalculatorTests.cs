using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalc.core;

namespace StringCalc.core.test
{
    [TestClass]
    public class StringCalculatorTests
    {
        StringCalculator target = null;

        [TestInitialize]
        public void Setup() {
            target = new StringCalculator();
        }

        [TestMethod]
        public void WhenNullOrEmptyString_ReturnZero()
        {
            var result = target.Add("");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void WhenOneNumber_ShouldReturnNumber() {
            var result = target.Add("1");
            Assert.AreEqual(1, result);
            result = target.Add("2");
            Assert.AreEqual(2, result);
            result = target.Add("1000");
            Assert.AreEqual(1000, result);
        }

        [TestMethod]
        public void WhenTwoNumbers_ShouldReturnSumOfTwoNumbers() {
            var result = target.Add("1,2");
            Assert.AreEqual(3, result);
            result = target.Add("100,1000");
            Assert.AreEqual(1100, result);
        }

        [TestMethod]
        public void WhenVariableLength_ShouldReturnSumOfAllNumbers() {
            var result = target.Add("1,2,3,4,5,6,7,8,9,10");
            Assert.AreEqual(55, result);
        }

        [TestMethod]
        public void WhenNewLine_ShouldSplitLikeComma() {
            var result = target.Add("1\n2");
            Assert.AreEqual(3, result);
            result = target.Add("1\n2\n3\n4\n5\n6\n7\n8\n9\n10");
            Assert.AreEqual(55, result);
        }

        [TestMethod]
        public void WhenCustomDelimiter_ShouldSplitLikeComma() {
            var result = target.Add("//;\n1;2");
            Assert.AreEqual(3, result);
        }
    }
}
