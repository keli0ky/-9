using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    { }
       

class Box<T>
    {
        private T item;

        public void Put(T item)
        {
            this.item = item;
        }

        public T Get()
        {
            return item;
        }
    }

    
    class Utils
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

   
    class Pair<T1, T2>
    {
        public T1 First { get; set; }
        public T2 Second { get; set; }

        public Pair(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }
    }

    class MainClass 
    {
        static void Main()
        {
            Console.WriteLine("Часть 1. Обобщённый класс");

           
            Box<int> intBox = new Box<int>();
            intBox.Put(4652);
            Console.WriteLine($"Число в коробке: {intBox.Get()}");

            
            Box<string> stringBox = new Box<string>();
            stringBox.Put("хэллоу");
            Console.WriteLine($"Строка в коробке: {stringBox.Get()}");

            Console.WriteLine(" Часть 2. Обобщённый метод");

            int num1 = 5536;
            int num2 = 10253;
            Console.WriteLine($"Числа до Swap: {num1}, {num2}");
            Utils.Swap(ref num1, ref num2);
            Console.WriteLine($"Числа после Swap: {num1}, {num2}");

            
            string str1 = "хэллоу";
            string str2 = "ван пис";
            Console.WriteLine($"Строки до Swap: {str1}, {str2}");
            Utils.Swap(ref str1, ref str2);
            Console.WriteLine($"Строки после Swap: {str1}, {str2}");

            Console.WriteLine("Часть 3. Пара значений");

            
            Pair<int, string> pair = new Pair<int, string>(5, "хэллоу");
            Console.WriteLine($"Первое значение: {pair.First}, Второе значение: {pair.Second}");

            Console.ReadKey(); 
        }
    }
}


