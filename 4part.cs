using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер 1 матрицы: ");
            int sizeOne = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите размер 2 матрицы: ");
            int sizeTwo = Convert.ToInt32(Console.ReadLine());

            Random rand1 = new Random();
            Random rand2 = new Random();

            int[,] matrix1 = GenerateAdjacencyMatrix(sizeOne, rand1);
            int[,] matrix2 = GenerateAdjacencyMatrix(sizeTwo, rand2);

            Console.WriteLine("Матрица G1:");
            PrintMatrix(matrix1);

            Console.WriteLine("Матрица G2:");
            PrintMatrix(matrix2);

            int[,] resultMatrix = MultiplyMatrices(matrix1, matrix2);

            Console.WriteLine("Матрица G = G1 X G2:");
            PrintMatrix(resultMatrix);

        }
        //Метод MultiplyMatrices принимает две матрицы смежности matrix1 и matrix2 и возвращает новую матрицу, которая является декартовым произведением этих двух матриц.

        static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int sizeOne = matrix1.GetLength(0);
            int sizeTwo = matrix2.GetLength(1);

            //Размер новой матрицы определяется как произведение размеров matrix1 и matrix2.
            int[,] matrix = new int[sizeOne* sizeTwo, sizeOne* sizeTwo];

            //Внутри метода используются четыре вложенных цикла for для перебора всех возможных комбинаций вершин из matrix1 и matrix2
            for (int i = 0; i < sizeOne; i++)
            {
                for (int j = 0; j < sizeOne; j++)
                {
                    for (int k = 0; k < sizeTwo; k++)
                    
                    {
                        for (int l = 0; l < sizeTwo; l++)
                        {
                            //Если в обоих матрицах соответствующие вершины имеют значение 1, то в новой матрице соответствующее ребро устанавливается в значение 1.
                            if (matrix1[i, j] == 1 && matrix2[k, l] == 1)
                    {
                matrix[i* sizeTwo +k, j* sizeTwo +l] = 1;
            }
        }
    }
}
}

    return matrix;
}
        //Метод GenerateAdjacencyMatrix генерирует случайную матрицу смежности для графа заданного размера
        private static int[,] GenerateAdjacencyMatrix(int size, Random rand)
        {

            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != j)
                    {
                        matrix[i, j] = rand.Next(2);
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
    }
}
