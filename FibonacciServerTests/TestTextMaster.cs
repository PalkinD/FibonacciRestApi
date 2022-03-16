using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;


namespace FibonacciServer
{
    [TestClass]
    public class TestTextMaster
    {
        [TestMethod]
        public void testTakeNumbersFromText()
        {
            const int first = 0;
            const int second = 1;

            //GIVEN
            int[] expectedFirst=new int[]{ 0,1,1,2,3,5};
            int[] expectedSecond = new int[] { 5,6,7 };
            string text = "0,1,1,2,3,5?asd 1 2 3?1,2,3 4 5 6 7?5 6 7";
            //"0,1,1,2,3,5?hello1,s2,3?wow,3 5,6,7?8 13 21 34"
            //WHEN
            RowOfNumbers[] result=TextMaster.TakeNumbersFromText(text);
            //THEN
            CollectionAssert.AreEquivalent(expectedFirst, result[first].Numbers);
            CollectionAssert.AreEquivalent(expectedSecond, result[second].Numbers);
        }
        }
 }

