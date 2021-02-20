using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rogueLike
{
    class Program
    {
        enum MapElements { Coin = 1, Wall, Portal }
        static void Main(string[] args)
        {
            //portal2 rogue like edition
            //элементы карты: 
            //1.персонаж - 0 - зеленый
            //2.монетки - $ - желтый
            //3.стены - # - коричневый
            //4.портал - @ - фиолетовый
            //5.враги - * - красный

            Random random = new Random();
            int width, height;
            int minSize = 10, maxSize = 20;
            int playerPositionI, playerPositionJ;
            int wallCount, coinCount;
            int elementPositionI, elementPositionJ;
            int score = 0;
            int[] inventory;

            int[,] map;

            bool isGamePlay = true;

            char playerChar = '0';
            char coinChar = '$';
            char wallChar = '#';
            char portalChar = '@';

            ConsoleColor playerColor = ConsoleColor.Green;
            ConsoleColor coinColor = ConsoleColor.Yellow;
            ConsoleColor wallColor = ConsoleColor.DarkRed;
            ConsoleColor portalColor = ConsoleColor.Magenta;

            //главный цикл игры
            while (isGamePlay == true)
            {
                width = random.Next(minSize, maxSize);
                height = random.Next(minSize, maxSize);

                map = new int[width, height];

                playerPositionI = random.Next(0, width);
                playerPositionJ = random.Next(0, height);

                coinCount = 10;
                wallCount = map.Length / 5;

                inventory = new int[coinCount];

                for (int i = 0; i < wallCount; i++)
                {
                    do
                    {
                        elementPositionI = random.Next(0, width);
                        elementPositionJ = random.Next(0, height);
                    }
                    while ((elementPositionI == playerPositionI && elementPositionJ == playerPositionJ) ||
                           map[elementPositionI, elementPositionJ] == (int)MapElements.Wall);

                    map[elementPositionI, elementPositionJ] = (int)MapElements.Wall;
                }

                for (int i = 0; i < coinCount; i++)
                {
                    do
                    {
                        elementPositionI = random.Next(0, width);
                        elementPositionJ = random.Next(0, height);
                    }
                    while ((elementPositionI == playerPositionI && elementPositionJ == playerPositionJ) ||
                           map[elementPositionI, elementPositionJ] == (int)MapElements.Wall ||
                           map[elementPositionI, elementPositionJ] == (int)MapElements.Coin);

                    map[elementPositionI, elementPositionJ] = (int)MapElements.Coin;
                }

                do
                {
                    elementPositionI = random.Next(0, width);
                    elementPositionJ = random.Next(0, height);
                }
                while ((elementPositionI == playerPositionI && elementPositionJ == playerPositionJ) ||
                           map[elementPositionI, elementPositionJ] == (int)MapElements.Wall ||
                           map[elementPositionI, elementPositionJ] == (int)MapElements.Coin);

                map[elementPositionI, elementPositionJ] = (int)MapElements.Portal;

                //цикл одного уровня
                while (true)
                {
                    Console.Clear();

                    Console.WriteLine($"Счёт: {score}\n");


                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkBlue;

                            switch ((MapElements)map[i, j])
                            {
                                case MapElements.Coin:
                                    Console.ForegroundColor = coinColor;
                                    Console.Write(coinChar);
                                    break;
                                case MapElements.Wall:
                                    Console.ForegroundColor = wallColor;
                                    Console.Write(wallChar);
                                    break;
                                case MapElements.Portal:
                                    Console.ForegroundColor = portalColor;
                                    Console.Write(portalChar);
                                    break;
                                default:
                                    if (i == playerPositionI && j == playerPositionJ)
                                    {
                                        Console.ForegroundColor = playerColor;
                                        Console.Write(playerChar);
                                    }
                                    else
                                    {
                                        Console.Write(' ');
                                    }
                                    break;
                            }

                            Console.ResetColor();
                        }
                        Console.WriteLine();
                    }

                    ConsoleKeyInfo userInput = Console.ReadKey();

                    switch (userInput.Key)
                    {
                        case ConsoleKey.W:
                            if (playerPositionI - 1 > -1 && map[playerPositionI - 1, playerPositionJ] != (int)MapElements.Wall)
                            {
                                playerPositionI--;
                            }
                            break;
                        case ConsoleKey.A:
                            if (playerPositionJ - 1 > -1 && map[playerPositionI, playerPositionJ - 1] != (int)MapElements.Wall)
                            {
                                playerPositionJ--;
                            }
                            break;
                        case ConsoleKey.S:
                            if (playerPositionI + 1 < map.GetLength(0) && map[playerPositionI + 1, playerPositionJ] != (int)MapElements.Wall)
                            {
                                playerPositionI++;
                            }
                            break;
                        case ConsoleKey.D:
                            if (playerPositionJ + 1 < map.GetLength(1) && map[playerPositionI, playerPositionJ + 1] != (int)MapElements.Wall)
                            {
                                playerPositionJ++;
                            }
                            break;
                    }
                    //проверить столкновение с порталом и монетами;
                    if (map[playerPositionI, playerPositionJ] == (int)MapElements.Coin)
                    {
                        for (int i = 0; i < inventory.Length; i++)
                        {
                            if (inventory[i] == 0)
                            {
                                inventory[i] = (int)MapElements.Coin;
                                break;
                            }
                        }

                        score++;

                        map[playerPositionI, playerPositionJ] = 0;
                    }

                    if (map[playerPositionI, playerPositionJ] == (int)MapElements.Portal)
                    {
                        bool canExit = true;
                        for (int i = 0; i < inventory.Length; i++)
                        {
                            if (inventory[i] == 0)
                            {
                                canExit = false;
                                break;
                            }
                        }
                 =       if (canExit == true)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
