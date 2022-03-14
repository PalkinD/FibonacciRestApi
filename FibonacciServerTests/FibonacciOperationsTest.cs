using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace FibonacciServer
{
    [TestClass]
    public class FibonacciOperationsTest
    {
        [TestMethod]
        public void testIsRowFibonacci()
        {
            //GIVEN
            bool expected = true;
            int [] given = { 0,1,1,2,3,5};
            //WHEN
            bool result = FibonacciOperations.IsRowFibonacci(given);
            //THEN
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void testIsRowFibonacci_WithRandomNumbers()
        {
            //GIVEN
            bool expected = false;
            int[] given = { 7,19,33,44 };
            //WHEN
            bool result = FibonacciOperations.IsRowFibonacci(given);
            //THEN
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void testIsRowFibonacci_WithNumbersThatAreFibonacci()
        {
            //GIVEN
            bool expected = false;
            int[] given = { 5,13,21 };
            //WHEN
            bool result = FibonacciOperations.IsRowFibonacci(given);
            //THEN
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void testIsRowFibonacci_WithLessThanTwoNumbers()
        {
            //GIVEN
            bool expected = false;
            int[] given = { 5,13};
            //WHEN
            bool result = FibonacciOperations.IsRowFibonacci(given);
            //THEN
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void testIsRowFibonacci_WithLessThanTwoNumbersRight()
        {
            //GIVEN
            bool expected = true;
            int[] given = { 5,8 };
            //WHEN
            bool result = FibonacciOperations.IsRowFibonacci(given);
            //THEN
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void testIsRowFibonacci_WithOneNumber()
        {
            //GIVEN
            bool expected = true;
            int[] given = { 13 };
            //WHEN
            bool result = FibonacciOperations.IsRowFibonacci(given);
            //THEN
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void testReverse()
        {
            //GIVEN
            int [] expected = { 5,3,2,1,1,0};
            RowOfNumbers row = new RowOfNumbers();
            row.Numbers = new int[] {0,1,1,2,3,5};
            //WHEN
            FibonacciOperations.Reverse(row);
            int[] result = row.Numbers;
            //THEN
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
