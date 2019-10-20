using System;

namespace ConsoleApp1
{
    class Program
    {
        public static double[] GaussMethod(double[,] mat)
        {
            Print(mat);
            int rows = mat.GetLength(0);
            int columns = mat.GetLength(1);
            double tmp, delta = 0.00001;

            for (var columnIterations = 0; columnIterations < rows; columnIterations++)
            {
                for (var i = columnIterations; i < rows; i++)
                {
                    tmp = mat[i, columnIterations];
                    if (Math.Abs(tmp) > delta)
                    {
                        for (var j = 0; j < columns; j++)
                        {
                            mat[i, j] /= tmp;
                        }
                    }

                    if (i != columnIterations)
                    {
                        for (var j = 0; j < columns; j++)
                        {
                            mat[i, j] -= mat[columnIterations, j];
                        }
                    }
                }
                Print(mat);
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

            for (var i = 0; i < solution.Length; i++)
            {
                if (solution[i] < delta)
                    solution[i] = 0;
            }

            return solution;
        }

        public static void Print(double[,] mat)
        {
            int rows = mat.GetLength(0);
            int columns = mat.GetLength(1);



            Console.WriteLine();
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    if ((mat[i, j] % 1).ToString().Length > 3)
                        Console.Write(Math.Round(mat[i, j], 2) + " ");
                    else Console.Write(mat[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var inputMatrix = new double[,] { { 5, 1, 1, 2, 2 }, { 2, 4, 1, 2, 5 }, { 1, 1, 3, 1, 4 }, { 1, 1, -1, 3, 0 } };
            var solution = GaussMethod(inputMatrix);
            for (var i = 0; i < solution.Length; i++)
            {
                Console.WriteLine("X{0} = {1}", i + 1, solution[i]);
            }
            Console.ReadLine();
        }
    }
}