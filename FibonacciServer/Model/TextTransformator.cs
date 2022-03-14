using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FibonacciServer
{
    public static class TextTransformator
    {
        public static RowOfNumbers [] TakeNumbersFromText(string text)
        {
            List<RowOfNumbers> rowsOFNumbers = new List<RowOfNumbers>();
            foreach (string row in text.Split(" "))
            {
                if(!Regex.IsMatch(row, "[a-zA-Zа-яА-Я]+|[a-zA-Zа-яА-Я]"))
                {
                    string[] symbols = row.Split(',');
                    RowOfNumbers numbers = new RowOfNumbers();
                    numbers.Numbers = new int[symbols.Length];
                   for(int i = 0; i < symbols.Length; i++)
                    {
                        numbers.Numbers[i] = Int32.Parse(symbols[i]);
                    }
                    rowsOFNumbers.Add(numbers);
                }
            }
            if (rowsOFNumbers.Count <= 0)
            {
                throw new Exception("No number rows");
            }
            return rowsOFNumbers.ToArray();
        }
    }
}
