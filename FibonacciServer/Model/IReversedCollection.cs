using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FibonacciServer
{
   public interface IReversedCollection<T>
    {
        public string GetReversedResults();// возвращает текстом все перевернутые строки
        public string GetOneReversedResult(int id);//возвращает текстом одну итерацию перевернутых строк
        public List<T> Add(params T[] values);// добавляет в коллекцию строки и возвращает только что добавленные перевернутые строки
        public void Clear();
        public void Delete(int id);//возвращает текстом одну итерацию перевернутых строк
        public int Count { get; }
    }
}
