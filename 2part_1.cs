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
            string menuOption;
            int[] verticesToIldentify;
            int[] verticesToContract;
            int vertexToSplit;

            Console.Write("Введите размер 1 матрицы: ");
            int sizeOne = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите размер 2 матрицы: ");
            int sizeTwo = Convert.ToInt32(Console.ReadLine());

            int[,] M1 = GenerateAdjacencyMatrix(sizeOne);
            int[,] M2 = GenerateAdjacencyMatrix(sizeTwo);

            do
            {
                Console.WriteLine("Выберите опцию:");
                Console.WriteLine("1.Просмотр матрицы (1)");
                Console.WriteLine("2.Отождествление вершин (1)");
                Console.WriteLine("3.Стягивание ребра (1)");
                Console.WriteLine("4.Расщепление вершины (1)" + "\n");

                Console.WriteLine("5.Просмотр матрицы (2)");
                Console.WriteLine("6.Отождествление вершин (2)");
                Console.WriteLine("7.Стягивание ребра (2)");
                Console.WriteLine("8.Расщепление вершины (2)" + "\n");

                Console.WriteLine("9.Выход");

                menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "1":
                        Console.WriteLine("Матрица смежности для графа G1:");
                        PrintMatrix(M1);
                        break;
                    case "2":
                        Console.Write("Введите номера вершин для отождествления (через пробел):");
                        verticesToIldentify = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                        IdentifyVertices(ref M1, verticesToIldentify[0], verticesToIldentify[1]);
                        break;
                    case "3":
                        Console.Write("Введите номера вершин для стягивания ребра (через пробел): ");
                        verticesToContract = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                        ContractEdge(ref M1, verticesToContract[0], verticesToContract[1]);
                        break;
                    case "4":
                        Console.Write("Введите номер вершины для расщепления: ");
                        vertexToSplit = int.Parse(Console.ReadLine());
                        SplitVertex(ref M1, vertexToSplit);
                        break;
                    case "5":
                        Console.WriteLine("Матрица смежности для графа G2:");
                        PrintMatrix(M2);
                        break;
                    case "6":
                        Console.Write("Введите номера вершин для отождествления (через пробел):");
                        verticesToIldentify = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                        IdentifyVertices(ref M2, verticesToIldentify[0], verticesToIldentify[1]);
                        break;
                    case "7":
                        Console.Write("Введите номера вершин для стягивания ребра (через пробел): ");
                        verticesToContract = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                        ContractEdge(ref M2, verticesToContract[0], verticesToContract[1]);
                        break;
                    case "8":
                        Console.Write("Введите номер вершины для расщепления: ");
                        vertexToSplit = int.Parse(Console.ReadLine());
                        SplitVertex(ref M2, vertexToSplit);
                        break;
                    case "9":
                        Console.WriteLine("Программа завершена");
                        break;
                    default:
                        Console.WriteLine("Неверная опция, попробуйте ещё раз");
                        break;
                }
                Console.WriteLine();
            } while (menuOption != "9");
        }
        //Метод GenerateAdjacencyMatrix генерирует случайную матрицу смежности для графа заданного размера.
        private static int[,] GenerateAdjacencyMatrix(int size)
        {
            Random rand1 = new Random();

            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    matrix[i, j] = rand1.Next(2);
                    matrix[j, i] = matrix[i, j];
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
        //Метод осуществляет отождествления вершин 
        static void IdentifyVertices(ref int[,] matrix, int vertex1, int vertex2)
        {
            //Сначала определяется размерность массива matrix с помощью метода GetLength(0) и присваивается переменной size.
            int size = matrix.GetLength(0);

            //Затем начинается первый цикл for для итерации по строкам массива matrix. Внутри цикла проверяется, что текущий индекс i не равен vertex1 и vertex2.
            //Если это условие выполняется и элемент matrix[i, vertex2] равен 1, то элемент matrix[i, vertex1] присваивается значение 1
            for (int i = 0; i < size; i++)
            {
                if (i != vertex1 && i != vertex2)
                {
                    if (matrix[i, vertex2] == 1)
                    {
                        matrix[i, vertex1] = 1;
                    }
                }
            }
            //После этого начинается второй цикл for для итерации по столбцам массива matrix. Внутри цикла проверяется, что текущий индекс j не равен vertex1 и vertex2.
            //Если это условие выполняется и элемент matrix[vertex2, j] равен 1, то элемент matrix[vertex1, j] присваивается значение 1
            for (int j = 0; j < size; j++)
            {
                if (j != vertex1 && j != vertex2)
                {
                    if (matrix[vertex2, j] == 1)
                    {
                        matrix[vertex1, j] = 1;
                    }
                }
            }
            //Затем следуют два цикла for, которые устанавливают все элементы в строке vertex2 и столбце vertex2 равными 0
            for (int i = 0; i < size; i++)
            {
                matrix[i, vertex2] = 0;
            }

            for (int j = 0; j < size; j++)
            {
                matrix[vertex2, j] = 0;
            }
        }
        //Метод осуществляет стягивание ребра
        static void ContractEdge(ref int[,] matrix, int vertex1, int vertex2)
        {
            //Сначала определяется размерность массива matrix с помощью метода GetLength(0) и присваивается переменной size.
            int size = matrix.GetLength(0);

            //Затем вызывается метод IdentifyVertices, который изменяет значения элементов массива matrix в соответствии с определенными условиями, связанными с вершинами vertex1 и vertex2.
            IdentifyVertices(ref matrix, vertex1, vertex2);

            //После этого создается новый двумерный массив newMatrix размером (size - 1) x (size - 1).
            int[,] newMatrix = new int[size - 1, size - 1];
            int newRow = 0;
            int newCol = 0;

            //Затем начинается первый цикл for для итерации по строкам массива matrix.
            for (int i = 0; i < size; i++)
            {
                //Внутри цикла проверяется, что текущий индекс i не равен vertex2
                if (i != vertex2)
                {
                    //Если это условие выполняется, то начинается второй цикл for для итерации по столбцам массива matrix.
                    for (int j = 0; j < size; j++)
                    {
                        //Внутри второго цикла проверяется, что текущий индекс j не равен vertex2.
                        if (j != vertex2)
                        {
                            //Если это условие выполняется, то элемент matrix[i, j] присваивается элементу newMatrix[newRow, newCol], а затем значение newCol увеличивается на 1.
                            newMatrix[newRow, newCol] = matrix[i, j];
                            newCol++;
                        }
                    }
                    //После завершения второго цикла for значение newRow увеличивается на 1, а newCol сбрасывается в 0.
                    newRow++;
                    newCol = 0;
                }
            }

            matrix = newMatrix;
        }

        //Метод осуществляет расщепление вершины
        //Ключевое слово ref указывает, что массив будет изменяться непосредственно в вызывающем коде.
        static void SplitVertex(ref int[,] matrix, int vertex)
        {
            //получение размера матрицы matrix. Метод GetLength(0) возвращает длину массива по указанному измерению (в данном случае по оси 0)
            int size = matrix.GetLength(0);

            //создание новой матрицы newMatrix с размерностью на 1 больше исходной матрицы matrix. Это нужно для добавления новой вершины.
            int[,] newMatrix = new int[size + 1, size + 1];

            // Вложенный цикл for используется для копирования существующих связей в новую матрицу:
            // В этом коде мы пробегаем по каждому элементу исходной матрицы matrix и копируем его в
            // новую матрицу newMatrix, за исключением связей с вершиной, которую мы разделяем.
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != vertex && j != vertex)
                    {
                        if (i > vertex && j > vertex)
                        {
                            newMatrix[i + 1, j + 1] = matrix[i, j];
                        }
                        else if (i > vertex)
                        {
                            newMatrix[i + 1, j] = matrix[i, j];
                        }
                        else if (j > vertex)
                        {
                            newMatrix[i, j + 1] = matrix[i, j];
                        }
                        else
                        {
                            newMatrix[i, j] = matrix[i, j];
                        }
                    }
                }
            }
            
            // Следующий цикл for используется для копирования ребер из разделенной вершины в новые вершины:
            for (int i = 0; i < size; i++)
            {
                if (i != vertex)
                {
                    newMatrix[vertex, i] = matrix[vertex, i];
                    newMatrix[i, vertex] = matrix[i, vertex];
                }
            }
            // обновление исходной матрицы matrix новой матрицей newMatrix, которая содержит добавленную вершину и соответствующие ребра.
            matrix = newMatrix;
        }

    }
}