using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FibonacciServer
{
    public static class FibonacciOperations
    {
        public static bool IsRowFibonacci(int[] numbers)
        {
            int previos = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < previos||!IsNumberFibonacci(numbers[i])||(i >= 2 && !IsNumberFibonacci(numbers[i], previos, numbers[i - 2])))
                {
                    return false;
                }
                previos = numbers[i];
            }
            if (numbers.Length == 2 && !IsNumberFibonacci(numbers[0]+numbers[1]))
            {
                return false;
            }         
            return true;
        }
        /* Натуральное число N является числом Фибоначчи тогда и только тогда, когда 5N^2 + 4 или 5N^2 - 4 является квадратом. 
         * Квадратное число — число, являющееся квадратом некоторого целого числа.*/
       private static bool IsNumberFibonacci(int number)
        {
            return Math.Sqrt(5 * (Math.Pow(number, 2)) - 4) % 1 == 0 || Math.Sqrt(5 * (Math.Pow(number, 2)) + 4) % 1 == 0;
        }
        /* Fn= Fn-1 + Fn-2 */
        private static bool IsNumberFibonacci(int number, int previosNumber, int previosForPreviosNumber)
        {
            return previosNumber + previosForPreviosNumber == number;
        }
        public static void Reverse(RowOfNumbers row)
        {
            int backward = row.Numbers.Length - 1;// последний элемент массива
            int forward = 0;
            int halfLengthfOfArray = row.Numbers.Length / 2;
            while (forward != halfLengthfOfArray)
            {
                int temp = row.Numbers[forward];
                row.Numbers[forward] = row.Numbers[backward];
                row.Numbers[backward] = temp;
                backward--;
                forward++;
            }
        }
    }
}
