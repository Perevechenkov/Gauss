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

            for (var columnIteration = 0; columnIteration < rows; columnIteration++)
            {
                for (var i = columnIteration; i < rows; i++)
                {
                    tmp = mat[i, columnIteration];
                    if (Math.Abs(tmp) > delta)
                    {
                        for (var j = 0; j < columns; j++)
                        {
                            mat[i, j] /= tmp;
                        }
                    }

                    if (i != columnIteration)
                    {
                        for (var j = 0; j < columns; j++)
                        {
                            mat[i, j] -= mat[columnIteration, j];
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

                if (Math.Abs(solution[i]) < delta)
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
                        mat[i, j] = Math.Round(mat[i, j], 2);
                    if (j == 4)
                        Console.Write(" = {0}", mat[i, j]);
                    else Console.Write("X{0} * {1} ", j + 1, mat[i, j]);
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