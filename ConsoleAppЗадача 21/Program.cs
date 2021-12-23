using System;
using System.Collections.Generic;
using System.Threading;

namespace Task21
{
    class Field
    {
        static int[,] arr = new int[10, 10];
        static void Main(string[] args)
        {
            //0 - невспаханная ячейка, 1 - вспаханная
            //заполняем массив 0ми
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    arr[i, j] = 0;
                }
            }
            //метод для полного вывода массива
            PrintField();

            Thread Gard1 = new Thread(Gardener1);
            Thread Gard2 = new Thread(Gardener2);
            Gard1.Start();
            Gard2.Start();
            //выводим значение 10 раз, чтобы видеть изменения
            for (int i = 0; i < 10; i++)
            {
                PrintField();
                Thread.Sleep(500);
            }
        }
        public static void Gardener1()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (arr[i, j] != 1)
                    {
                        arr[i, j] = 1;
                    }
                    else
                    {
                        break;
                    }
                    Thread.Sleep(75);
                }
            }
            Thread.CurrentThread.Interrupt();
        }
        public static void Gardener2()
        {
            for (int i = 9; i >= 0; i--)
            {
                for (int j = 9; j >= 0; j--)
                {
                    if (arr[j, i] != 1)
                    {
                        arr[j, i] = 1;
                    }
                    else
                    {
                        break;
                    }
                    Thread.Sleep(75);
                }
            }
            Thread.CurrentThread.Interrupt();
        }
        public static void PrintField()
        {
            for (int i = 0; i < 10; i++)
            {
                List<int> strList = new List<int>();
                for (int j = 0; j < 10; j++)
                {
                    strList.Add(arr[i, j]);
                }
                Console.WriteLine(String.Join(" ", strList));
                strList.Clear();
            }
            Console.WriteLine();
        }
    }
}

