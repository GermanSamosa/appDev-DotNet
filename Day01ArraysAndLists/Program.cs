using System;

namespace Day01ArraysAndLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // possibly a jagged array, only the first dimension is allocated
            int[][] twoDimInt = new int[4][];
            // rectangular array
            int[,] twoDimIntRectangular = new int[4, 3];
            int[,,] threeDimIntRect = new int[4, 3, 2]; // 3D: 4 x 3 x 2 size

            int[,] data2dInts = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 18 } };
            try
            {
                //start
                float average = 0.0F;

                int rows = data2dInts.GetLength(0);
                int cols = data2dInts.GetLength(1);

                for (int i = 0; i < rows; i++)
                    try
                    {
                        {
                            for (int x = 0; x < cols; x++)
                            {
                                average += data2dInts[i, x];
                            }
                            average /= cols;
                            Console.Write("the average of row {0} is = {1}", i, average);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("index out of bounds");

                    }
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
