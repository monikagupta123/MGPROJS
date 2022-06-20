using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeChecker;

namespace CodeCheckerTest
{
    [TestClass]
    public class CodeCheckerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            string strToCheck = "()"; 
            bool expected = true;
            // Act
            bool result = LPISCodeChecker.CodeChecker(strToCheck);

            // Assert
            
            Assert.AreEqual(expected, result, "Balanced");
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            string strToCheck = "()]";
            bool expected = false;
            // Act
            bool result = LPISCodeChecker.CodeChecker(strToCheck);
            // Assert
            Assert.AreEqual(expected, result, "Not Balanced");
        }
        [TestMethod]
        public void TestMethod3()
        {
            // Arrange
            string strToCheck = "{adasf()";
            bool expected = false;
            // Act
            bool result = LPISCodeChecker.CodeChecker(strToCheck);
            // Assert
            Assert.AreEqual(expected, result, "Not Balanced");
        }
    }
}
