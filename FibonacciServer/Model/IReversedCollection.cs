using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FibonacciServer
{
   public interface IReversedCollection<T>
    {
        public ICollection<T> GetReversedResults();// возвращает все перевернутые строки
        public ICollection<T> Add(params T[] values);// добавляет в коллекцию строки и возвращает только что добавленные перевернутые строки
        public void Clear(); 
    }
}
