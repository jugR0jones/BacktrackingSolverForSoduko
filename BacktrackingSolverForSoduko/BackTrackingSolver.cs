using System;

namespace SodukoSolving
{

    public class BackTrackingSolver
    {

        // Structure to store the point
        public class Point
        {
            public int X;
            public int Y;

            public Point(int i, int j)
            {
                this.X = i;
                this.Y = j;
            }
        }

        private readonly int[,] _originalGrid;
        
        public BackTrackingSolver(int[,] grid)
        {
            _originalGrid = grid;
        }

        public void Solve()
        {
            int [,] solution = (int[,])_originalGrid.Clone();

            // Use the original grid as a starting point for the solution.
            if(this.BackTrack(solution))
            {
                this.OutputSolution(solution);
            } else
            {
                Console.WriteLine("No solution exists for the grid:");
                this.OutputSolution(_originalGrid);
            }
        }

        private bool BackTrack(int[,] c)
        {
            // Get the location that contains the first unassigned value - this is the starting point for the solution
            Point p = this.StartingSolution(c);
            if(p == null)
            {
                return true;
            }

            for(int i=1; i <= 9; i++)
            {
                if(this.IsSafe(c, p, i))
                {
                    // Looks like a promising solution
                    c[p.X, p.Y] = i;

                    if(this.BackTrack(c))
                    {
                        return true;
                    }

                    // Reset and try again
                    c[p.X, p.Y] = 0;
                }
            }
    
            return false;
        }

        // Return the first solution
        private Point StartingSolution(int[,] grid)
        {
            int width = grid.GetLength(0);
            int height = grid.GetLength(1);

            for(int i=0; i < width; i++)
            {
                for(int j=0; j < height; j++)
                {
                    if(grid[i, j] == 0)
                    {
                        return new Point(i, j);
                    }
                }
            }

            return null;
        }

        private bool IsSafe(int[,] grid, Point p, int num)
        {
            // Check if the 'num' is not already placed in the current row, colum or 3x3 box
            return !this.UsedInRow(grid, p, num)
                && !this.UsedInColumn(grid, p, num)
                && !this.UsedInBox(grid, p, num);
        }

        private bool UsedInRow(int[,] grid, Point p, int num)
        {
            int width = grid.GetLength(1);

            for(int i=0; i < width; i++)
            {
                if(grid[p.X, i] == num)
                {
                    return true;
                }
            }

            return false;
        }

        private bool UsedInColumn(int[,] grid, Point p, int num)
        {
            int height = grid.GetLength(0);

            for(int i=0; i < height; i++)
            {
                if(grid[i, p.Y] == num)
                {
                    return true;
                }
            }

            return false;
        }

        private bool UsedInBox(int[,] grid, Point p, int num)
        {
            int boxStartRow = p.X - p.X % 3;
            int boxStartCol = p.Y - p.Y % 3;

            for(int i=boxStartRow; i < boxStartRow+3; i++)
            {
                for(int j=boxStartCol; j < boxStartCol+3; j++)
                {
                    if (grid[i, j] == num)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void OutputSolution(int [,] grid)
        {
            int width = grid.GetLength(0);
            int height = grid.GetLength(1);

            for (int i=0; i < width; i++)
            {
                for(int j=0; j < height; j++)
                {
                    Console.Write("{0} ", grid[i,j]);
                }

                Console.WriteLine();
            }
        }

    }
}
