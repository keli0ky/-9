using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        public class Student
        {
            unsafe static void Main(string[] args)
            {
                ProcessArrayWithPointer();
                Console.WriteLine();
                ProcessDoublePointer();
            }

            static unsafe void ProcessArrayWithPointer()
            {
                Console.WriteLine("Работа с массивом через указатель");

                int[] numbers = { 1, 2, 3, 4, 5 };

                Console.Write("До: ");
                PrintArray(numbers);

                
                fixed (int* p = numbers)
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        *(p + i) += 10; 
                    }
                }

                Console.Write("После: ");
                PrintArray(numbers);
            }

            static unsafe void ProcessDoublePointer()
            {
                Console.WriteLine("Работа с указателем на указатель");

                int x = 50;
                int* p = &x;
                int** pp = &p;

                Console.WriteLine($"Адрес x: 0x{(ulong)&x:X}");
                Console.WriteLine($"Адрес p: 0x{(ulong)&p:X}");
                Console.WriteLine($"Значение x до: {x}");

                **pp = 999; 

                Console.WriteLine($"Значение x после изменения через **pp: {x}");
            }

            static void PrintArray(int[] array)
            {
                foreach (int num in array)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}




