using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FibonacciServer
{
    public class FibonacciReversedRows : IReversedCollection<RowOfNumbers>
    {
        private List<List<RowOfNumbers>> _rowsOfNumbers;
        public int Count { get => _rowsOfNumbers.Count; }
        public FibonacciReversedRows()
        {
            _rowsOfNumbers = new List<List<RowOfNumbers>>();
        }
        public List<RowOfNumbers> Add(params RowOfNumbers[] values)
        {
            List<RowOfNumbers> rowsOfNumbers = new List<RowOfNumbers>();
            foreach (var row in values) {

                if (FibonacciOperations.IsRowFibonacci(row.Numbers))
                {
                    FibonacciOperations.Reverse(row);
                    rowsOfNumbers.Add(row);
                }
            }
            _rowsOfNumbers.Add(rowsOfNumbers);
            return rowsOfNumbers;
        }
        public string GetReversedResults()// to think
        {
            string result = "{\n";
            for (int i=0;i<Count;i++)
            {
                result +=i+":"+TextMaster.GetResultsInText(_rowsOfNumbers[i]) + "\n";
            }
            result += "}";
            return result;
        }
        public void Clear()
        {
            _rowsOfNumbers.Clear();
        }

        public string GetOneReversedResult(int id)
        {
            if (id > Count)
            {
                throw new Exception("There is no such element");
            }
            return TextMaster.GetResultsInText(_rowsOfNumbers[id]);
        }

        public void Delete(int id)
        {
            if (id > Count)
            {
                throw new Exception("There is no such element");
            }
            _rowsOfNumbers.RemoveAt(id);
        }
    }
}
