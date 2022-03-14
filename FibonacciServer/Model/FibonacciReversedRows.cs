using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FibonacciServer
{
    public class FibonacciReversedRows : IReversedCollection<RowOfNumbers>
    {
        private List<RowOfNumbers> _rowsOfNumbers;
        public int Count { get => _rowsOfNumbers.Count; }
        public FibonacciReversedRows()
        {
            _rowsOfNumbers = new List<RowOfNumbers>();
        }
        public FibonacciReversedRows(List<RowOfNumbers> rowsOfNumbers)
        {
            _rowsOfNumbers = new List<RowOfNumbers>();
            _rowsOfNumbers.AddRange(rowsOfNumbers);
        }
        public IReversedCollection<RowOfNumbers> Add(params RowOfNumbers[] values)
        {
            List<RowOfNumbers> rowsOfNumbers = new List<RowOfNumbers>();
            foreach (var row in values) {

                if (FibonacciOperations.IsRowFibonacci(row.Numbers))
                {
                    FibonacciOperations.Reverse(row);
                    rowsOfNumbers.Add(row);
                }
            }
            _rowsOfNumbers.AddRange(rowsOfNumbers);
            return new FibonacciReversedRows(rowsOfNumbers);
        }
        public string GetReversedResults()
        {
            string result = "";
            foreach(var row in _rowsOfNumbers)
            {
                result += row.ToString() + "\n";
            }
            return result;
        }
        public void Clear()
        {
            _rowsOfNumbers.Clear();
        }
    }
}
