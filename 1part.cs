using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер 1 матрицы: ");
            int sizeOne = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите размер 2 матрицы: ");
            int sizeTwo = Convert.ToInt32(Console.ReadLine());
            int[,] M1 = GenerateAdjacencyMatrix(sizeOne);
            int[,] M2 = GenerateAdjacencyMatrix(sizeTwo);

            Console.WriteLine("Матрица смежности для графа G1:");
            PrintMatrix(M1);

            Console.WriteLine("Матрица смежности для графа G2:");
            PrintMatrix(M2);

            List<List<int>> adjList1 = ConvertToAdjacecnyList(M1);
            List<List<int>> adjList2 = ConvertToAdjacecnyList(M2);

            Console.WriteLine("Список смежности для графа G1:");
            PrintAdjacencyList(adjList1);

            Console.WriteLine("Список смежности для графа G2:");
            PrintAdjacencyList(adjList2);
        }

        // Метод для генерации матрицы смежности
        // Метод создает объект класса Random для генерации случайных чисел и затем заполняет элементы матрицы
        // случайными значениями 0 или 1, за исключением диагональных элементов, которые остаются равными 0.
        private static int[,] GenerateAdjacencyMatrix(int size)
        {
            Random rand1 = new Random();

            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != j)
                    {
                        matrix[i, j] = rand1.Next(2);
                        matrix[j, i] = matrix[i, j];
                    }
                }
            }
            return matrix;
        }
        // Метод для вывода матрицы на экран
        static void PrintMatrix(int[,] matrix)
        {
            int size = matrix.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Метод для преобразования матрицы смежности в список смежности
        static List<List<int>> ConvertToAdjacecnyList(int[,] matrix)
        {
            //объявление переменной size и присваивание ей значения равного длине первого измерения массива matrix.
            int size = matrix.GetLength(0);
            List<List<int>> adjList = new List<List<int>>();

            for (int i = 0; i < size; i++)
            {
                //Объявление переменной neighbors и создание нового пустого списка целых чисел для хранения смежных вершин.
                List<int> neighbors = new List<int>();

                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        neighbors.Add(j + 1);
                    }
                }
                //добавление списка neighbors в список adjList, представляющий список смежности для вершины i.
                adjList.Add(neighbors);
            }
            return adjList;
        }
        // Метод для вывода списка смежности на экран
        // Метод проходит по каждой вершине в списке и для каждой вершины выводит ее номер и список смежных вершин.
        // Каждая вершина и ее смежные вершины выводятся в формате номер_вершины: список_смежных_вершин.
        static void PrintAdjacencyList(List<List<int>>adjList)
        {
            int size = adjList.Count;

            for (int i = 0; i < size; i++)
            {
                Console.Write(i+1 + ": ");

                foreach (int neihbor in adjList[i])
                {
                    Console.Write(neihbor + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
