using System;

namespace ConsoleApp1
{
    class Program
    {
        public static double[,] CreateMatrix(int rows, int columns)
        {
            var result = new double[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    Console.WriteLine("Введите {0} элемент {1} строки: ", j, i);
                    result[i, j] = double.Parse(Console.ReadLine());
                }
            }
            Print(result, rows, columns);
            return result;
        }

        public static double[] GaussMethod(double[,] mat, int rows, int columns)
        {
            double tmp;
            for (var iteration = 0; iteration < rows; iteration++)
            {
                var index = FindMaxRow(mat, iteration, rows);
                if (index != iteration)
                {
                    SwapRows(ref mat, iteration, index, columns);
                }

                for (var i = iteration; i < rows; i++)
                {
                    tmp = mat[i, iteration];
                    if (Math.Abs(tmp) > 0.00001)
                    {
                        for (var j = 0; j < columns; j++)
                        {
                            mat[i, j] /= tmp;
                        }
                    }

                    if (i != iteration)
                    {
                        for (var j = 0; j < columns; j++)
                        {
                            mat[i, j] -= mat[iteration, j];
                        }
                    }
                }
                Print(mat, rows, columns);
            }
            var solution = new double[columns - 1];
            for (var i = 0; i < rows; i++)
            {
                solution[i] = mat[i, columns - 1];
            }
            for (var i = rows - 2; i >= 0; i--)
            {
                for (var j = i + 1; j < rows; j++)
                {
                    solution[i] -= solution[j] * mat[i, j];
                }
            }
            return solution;
        }

        public static void Print(double[,] matrix, int rows, int columns)
        {
            Console.WriteLine();
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();
        }

        public static void SwapRows(ref double[,] matrix, int iteration, int index, int columns)
        {
            double tmp;
            for (var i = 0; i < columns; i++)
            {
                tmp = matrix[iteration, i];
                matrix[iteration, i] = matrix[index, i];
                matrix[index, i] = tmp;
            }
        }

        public static int FindMaxRow(double[,] matrix, int iteration, int rows)
        {
            var index = iteration;
            var max = Math.Abs(matrix[iteration, iteration]);
            for (int i = iteration + 1; i < rows; i++)
            {
                if (Math.Abs(matrix[i, iteration]) > max)
                {
                    max = Math.Abs(matrix[i, iteration]);
                    index = i;
                }
            }
            return index;
        }

        static void Main(string[] args)
        {
            var mat = new double[,] { { 1, 4, 3, 10 }, { 2, 1, -1, -1 }, { 3, -1, 1, 11 } };
            var solution = GaussMethod(mat, 3, 4);
            for (var i = 0; i < solution.Length; i++)
            {
                Console.WriteLine("X{0} = {1}", i + 1, solution[i]);
            }
            Console.ReadLine();
        }
    }
}