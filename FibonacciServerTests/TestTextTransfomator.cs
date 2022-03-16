using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;


namespace FibonacciServer
{
    [TestClass]
    public class TestTextTransfomator
    {
        [TestMethod]
        public void testTakeNumbersFromText()
        {
            const int first = 0;
            const int second = 1;

            //GIVEN
            int[] expectedFirst=new int[]{ 0,1,1,2,3,5};
            int[] expectedSecond = new int[] { 5,6,7 };
            string text = "0,1,1,2,3,5?8 13 21 34";
            //"0,1,1,2,3,5?hello1,s2,3?wow,3 5,6,7?8 13 21 34"
            //WHEN
            RowOfNumbers[] result=TextMaster.TakeNumbersFromText(text);
            //THEN
            CollectionAssert.AreEquivalent(expectedFirst, result[first].Numbers);
            CollectionAssert.AreEquivalent(expectedSecond, result[second].Numbers);
        }
        }
 }

