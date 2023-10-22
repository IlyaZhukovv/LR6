using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    internal class Program
    {
        //Метод GenerateAdjacencyMatrix генерирует случайную матрицу смежности для графа заданного размера.
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
        //Метод Union выполняет операцию объединения
        private static int[,] Union(int[,] matrix1, int[,] matrix2)
        {
            //Метод Union создает новую матрицу размером, равным максимальному размеру из matrix1 и matrix2
            int size = Math.Max(matrix1.GetLength(0), matrix2.GetLength(0));
            int[,] result = new int[size, size];

            //Затем он перебирает все элементы новой матрицы и устанавливает значения, используя значения из matrix1 и matrix2
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //Если элемент существует в обоих матрицах, то значение в новой матрице будет равно 1, иначе 0.
                    if (i < matrix1.GetLength(0) && j < matrix1.GetLength(1))
                    {
                        result[i, j] = matrix1[i, j];
                    }
                    if (i < matrix2.GetLength(0) && j < matrix2.GetLength(1))
                    {
                        result[i, j] |= matrix2[i, j];
                    }
                }
            }

            return result;
        }

        //Метод Intersection выполняет операцию пересечения
        private static int[,] Intersection(int[,] matrix1, int[,] matrix2)
        {
            //Метод Intersection также создает новую матрицу размером, равным максимальному размеру из matrix1 и matrix2
            int size = Math.Max(matrix1.GetLength(0), matrix2.GetLength(0));
            int[,] result = new int[size, size];

            //Затем он перебирает все элементы новой матрицы и устанавливает значения, используя значения из matrix1 и matrix2
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //Если элемент существует в обоих матрицах, то значение в новой матрице будет равно 1, иначе 0.
                    if (i < matrix1.GetLength(0) && j < matrix1.GetLength(1) && i < matrix2.GetLength(0) && j < matrix2.GetLength(1))
                    {
                        result[i, j] = matrix1[i, j] & matrix2[i, j];
                    }
                }
            }

            return result;
        }

        //Метод RingSum выполняет операцию кольцевой суммы
        private static int[,] RingSum(int[,] matrix1, int[,] matrix2)
        {
            //Объявление переменной size и присваивание ей значения максимального измерения(строк или столбцов) между matrix1 и matrix2, используя метод Math.Max.
            int size = Math.Max(matrix1.GetLength(0), matrix2.GetLength(0));
            //создает новую матрицу размером, равным максимальному размеру из matrix1 и matrix2
            int[,] result = new int[size, size];

            //Затем он перебирает все элементы новой матрицы и устанавливает значения, используя значения из matrix1 и matrix2.
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //Если элемент существует только в одной из матриц, то значение в новой матрице будет равно 1, иначе 0.
                    if (i < matrix1.GetLength(0) && j < matrix1.GetLength(1))
                    {
                        result[i, j] = matrix1[i, j];
                    }
                    if (i < matrix2.GetLength(0) && j < matrix2.GetLength(1))
                    {
                        //Применение операции побитового исключающего ИЛИ (^=) к элементу массива result[i, j] и элементу массива matrix2[i, j].
                        //Результат присваивается обратно элементу массива result[i, j].
                        result[i, j] ^= matrix2[i, j];
                    }
                }
            }

            return result;
        }

        // Пример использования
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

            Console.WriteLine("Объединение G1 и G2:");
            int[,] unionMatrix = Union(matrix1, matrix2);
            PrintMatrix(unionMatrix);

            Console.WriteLine("Пересечение G1 и G2:");
            int[,] intersectionMatrix = Intersection(matrix1, matrix2);
            PrintMatrix(intersectionMatrix);

            Console.WriteLine("Кольцевая сумма G1 и G2:");
            int[,] ringSumMatrix = RingSum(matrix1, matrix2);
            PrintMatrix(ringSumMatrix);
        }

    }
}
