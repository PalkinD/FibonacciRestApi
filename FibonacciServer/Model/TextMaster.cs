﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FibonacciServer
{
    public static class TextMaster
    {
        //public static RowOfNumbers[] TakeNumbersFromText(string text)
        //{
        //    string regex = "[a-zA-Zа-яА-Я]+|[a-zA-Zа-яА-Я]";
        //    const string specialSymbol = "?";
        //    List<RowOfNumbers> rowsOFNumbers = new List<RowOfNumbers>();
        //    foreach (string row in text.Split(specialSymbol))
        //    {
        //        if (Regex.IsMatch(row, regex))
        //        {
        //            string[] symbols = row.Split(',');
        //            RowOfNumbers numbers = new RowOfNumbers();
        //            numbers.Numbers = new int[symbols.Length];
        //            for (int i = 0; i < symbols.Length; i++)
        //            {
        //                numbers.Numbers[i] = Int32.Parse(symbols[i]);
        //            }
        //            rowsOFNumbers.Add(numbers);
        //        }
        //    }
        //    if (rowsOFNumbers.Count <= 0)
        //    {
        //        throw new Exception("No number rows");
        //    }
        //    return rowsOFNumbers.ToArray();
        //}
        public static RowOfNumbers[] TakeNumbersFromText(string text)
        {
            const string specialSymbol = "?";
            const string Space = " ";
            const string Comma = ",";
            const string CommaWithSpace = ", ";
            List<RowOfNumbers> rowsOFNumbers = new List<RowOfNumbers>();
            foreach (string row in text.Split(specialSymbol))
            {
                if (isMatch(Space, row))
                {
                   rowsOFNumbers.Add(obtainNumbersFromRow(Space, row));
                }
                if (isMatch(Comma, row))
                {
                    rowsOFNumbers.Add(obtainNumbersFromRow(Comma, row));
                }
                if (isMatch(CommaWithSpace, row))
                {
                    rowsOFNumbers.Add(obtainNumbersFromRow(CommaWithSpace, row));
                }
            }
            if (rowsOFNumbers.Count <= 0)
            {
                throw new Exception("No consistent rows");
            }
            return rowsOFNumbers.ToArray();
        }
        private static bool isMatch(string separator,string row)
        {
            string regex = @"(\d,)*\d{1}";
            return Regex.IsMatch(row, regex);
        }
        private static RowOfNumbers  obtainNumbersFromRow(string separator,string row)
        {
            string[] symbols = row.Split(',');
            RowOfNumbers numbers = new RowOfNumbers();
            numbers.Numbers = new int[symbols.Length];
            for (int i = 0; i < symbols.Length; i++)
            {
                numbers.Numbers[i] = Int32.Parse(symbols[i]);
            }
            return numbers;
        }
        public static string GetResultsInText(List<RowOfNumbers> rowsOfNumbers)
        {
            int lastElement = rowsOfNumbers.Count - 1;
            string result = "   [";
            for (int i = 0; i < rowsOfNumbers.Count; i++)
            {
                result += rowsOfNumbers[i].ToString();
                if (i != lastElement)
                {
                    result += "\n     ";
                }
            }
            result += "]";
            return result;
        }

        
    }
}
