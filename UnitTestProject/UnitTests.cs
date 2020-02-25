using Microsoft.VisualStudio.TestTools.UnitTesting;
using RightTriangleArea;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void RightValues_Test()
        {
            // Arrange
            double a = 6;
            double b = 8;
            double c = 10;
            double area1 = 24;
            double area2 = TriangleArea.Area(a, b, c);
            Assert.AreEqual(area1, area2);
        }

        [TestMethod]
        public void NegativeValue_Test()
        {
            // Arrange
            double a = -6;
            double b = 8;
            double c = 10;
            try
            {
                TriangleArea.Area(a, b, c);
            }
            catch(ArgumentException e)
            {
                StringAssert.Contains(e.Message, ConstMessage.NegativeValues);
            }
        }

        [TestMethod]
        public void IncorrectLegLength_Test()
        {
            double a = 9;
            double b = 9;
            double c = 8;
            try
            {
                TriangleArea.Area(a, b, c);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, ConstMessage.TwoBigEqualsSides);
            }
        }

        [TestMethod]
        public void SquaredParametersInfinity_Test()
        {
            double a = double.MaxValue / 2;
            double b = 15;
            double c = double.MaxValue - 10;
            try
            {
                TriangleArea.Area(a, b, c);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, ConstMessage.SquaredParameterInfinity);
            }
        }

        [TestMethod]
        public void TriangleExists_Test()
        {
            double a = 1;
            double b = 2;
            double c = 3;
            try
            {
                TriangleArea.Area(a, b, c);
            }
            catch (ArgumentException e)
            {
                StringAssert.Contains(e.Message, ConstMessage.WrongValues);
            }
        }
    }
}
