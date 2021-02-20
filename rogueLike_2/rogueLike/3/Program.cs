using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            int move = int.Parse(Console.ReadLine());
            int[] tempArray = new int[move];

            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(10, 45);
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = array[array.Length - i - 1];
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (i >= move)
                {
                    array[i] = array[i - move];
                }
                else
                {
                    array[i] = tempArray[tempArray.Length - i - 1];
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
