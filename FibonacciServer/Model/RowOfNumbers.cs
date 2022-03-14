using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FibonacciServer
{
    public record RowOfNumbers
    {
       public int [] Numbers { get; set; }

        public override string ToString()
        {
            const int first = 0;
            string result = Numbers[first].ToString();
           for(int i = 1; i < Numbers.Length; i++)
            {
                result += "," + Numbers[i];
            }
            return result;
        }
    }
}
