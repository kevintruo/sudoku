using System;
using System.Collections.Generic;
using System.Linq;
namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[,] test = new int[,] {
                {0,11,0,0,2,9,1,0,0}, 
                {0,0,5,0,0,0,9,6,0}, 
                {2,0,0,5,0,1,0,0,0}, 
                {8,2,0,1,0,0,7,0,3},
                {9,3,6,0,0,0,2,0,8}, 
                {0,0,7,8,3,0,0,9,6}, 
                {3,0,1,0,0,7,6,0,9}, 
                {7,0,2,9,0,0,5,0,1},
                {4,0,9,0,0,3,0,0,0}
            };
            Sudoku s = new Sudoku(test);
            s.displayBoard();
            Console.WriteLine(s.isBoardValid(test));
            
        }
    }
}