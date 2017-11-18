using System;

namespace SodukoSolving
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] sodukoGrid = new int[,] {
                {0,0,0, 0,0,0, 0,0,0},
                {0,0,0, 0,0,3, 0,8,5},
                {0,0,1, 0,2,0, 0,0,0},

                {0,0,0, 5,0,7, 0,0,0},
                {0,0,4, 0,0,0, 1,0,0},
                {0,9,0, 0,0,0, 0,0,0},

                {5,0,0, 0,0,0, 0,7,3},
                {0,0,2, 0,1,0, 0,0,0},
                {0,0,0, 0,4,0, 0,0,9},
            };

            BackTrackingSolver backTracking = new BackTrackingSolver(sodukoGrid);
            backTracking.Solve();

            Console.ReadLine();
        }
    }
}
