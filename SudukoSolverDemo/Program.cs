using System;

namespace SudukoSolverDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixLength = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixLength, matrixLength];
            for (int row = 0; row < matrixLength; row++)
            {
                var line = Console.ReadLine();
                var value = line.Split(" ");
                for (int col = 0; col < matrixLength; col++)
                {
                    matrix[row, col] = int.Parse(value[col]);
                }
            }

            Suduko(matrix, 0, 0, matrix.GetLength(0)-1, matrix.GetLength(1)-1);
            
            Console.ReadKey();
        }
        public static void Suduko(int[,] grid, int cr, int cc, int er, int ec)
        {

            if (cr > er)
            {
                Display(grid);
                return;
            }
            if (cc > ec)
            {
                Suduko(grid, cr + 1, 0, er, ec);
                return;
            }
            if (grid[cr, cc] != 0)
            {
                Suduko(grid, cr, cc + 1, er, ec);
                return;
            }
            for (int i = 1; i <= 9; i++)
            {
                if (Safe(grid, cr, cc, i))
                {
                    grid[cr, cc] = i;
                    Suduko(grid, cr, cc + 1, er, ec);
                    grid[cr, cc] = 0;
                }
                    
            }
            
        }

        public static bool Safe(int[,] grid, int row, int col, int value)
        {
            for (int c = 0; c < grid.GetLength(1); c++)
            {
                if (grid[row, c] == value)
                {
                    return false;
                }
            }
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                if (grid[r, col] == value)
                {
                    return false;
                }
            }
            int ROW = row - (row % 3);
            int COL = col - (col % 3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i + ROW, j + COL] == value)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void Display(int[,] grid)
        {
            Console.WriteLine("---- Solution ---- ");
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    Console.Write(grid[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
