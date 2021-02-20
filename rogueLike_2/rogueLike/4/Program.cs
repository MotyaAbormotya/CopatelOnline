using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[5 , 5];
            int move = int.Parse(Console.ReadLine());
            int[,] tempArray = new int[move, move];

            Random random = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1);j ++)
                {
                array[i, j] = random.Next(10, 45);
                }
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
            }

            Console.WriteLine();

            for (int i = 0; i < tempArray.GetLength(0); i++)
            {
                for (int j = 0; j < tempArray.GetLength(1); j++)
                {
                    tempArray[i, j] = array[i, j];
                }
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i >= move && j >= move)
                    {
                        array[i, j] = array[i - move, j - move];
                    }
                    else
                    {
                        array[i, j] = tempArray[i - 1, j - 1];
                    }
                }
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
