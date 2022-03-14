using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FibonacciServer
{
    public class FibonacciReversedRows : IReversedCollection<RowOfNumbers>
    {
        private List<RowOfNumbers> _rowsOfNumbers;
        public FibonacciReversedRows()
        {
            _rowsOfNumbers = new List<RowOfNumbers>();
        }
        public ICollection<RowOfNumbers> Add(params RowOfNumbers[] values)
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
            return rowsOfNumbers;
        }
        public ICollection<RowOfNumbers> GetReversedResults()
        {
            return new List<RowOfNumbers>(_rowsOfNumbers);
        }
        public void Clear()
        {
            _rowsOfNumbers.Clear();
        }
    }
}
