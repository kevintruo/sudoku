using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // //Completed board
            // int[,] board = new int[,] {
            //     {7,9,2,1,5,4,3,8,6},
            //     {6,4,3,8,2,7,1,5,9},
            //     {8,5,1,3,9,6,7,2,4},
            //     {2,6,5,9,7,3,8,4,1},
            //     {4,8,9,5,6,1,2,7,3},
            //     {3,1,7,4,8,2,9,6,5},
            //     {1,3,6,7,4,8,5,9,2},
            //     {9,7,4,2,1,5,6,3,8},
            //     {5,2,8,6,3,9,4,1,7}
            // };

            //Sudoku obj
            Sudoku s = new Sudoku();

            //Declare variables
            int main = -1, numb = -1, diff = -1;
            string? coord = "";
            while(diff != 4){
                s.displayDifficulty();
                diff = getInput(@"^[1-4]$");
                s.setBoardDiff(diff);
                if(diff == 4)
                    return;
                s.displayBoard();
                s.displayMainMenu();
                main = getInput(@"^[1-4]$");
            }
            // //While loop through
            // while (numb1 != 3)
            // {
            //     //s.displayBoard();
            //     //Display menu 
            //     //s.displayMainMenu();
            //     //Get input from 1 to 3
            //     numb1 = getInput(@"^[1-3]$");
            //     //Switch statement
            //     switch (numb1)
            //     {
            //         case 1: //Play game
            //             s = new Sudoku();
            //             if (!s.isBoardValid(s.getSetBoard()))
            //             {
            //                 Console.WriteLine("Your board is invalid");
            //                 Thread.Sleep(500);
            //                 break;
            //             }

            //             s.displayBoard(); //Display board
            //             //Reset input
            //             coord = "";
            //             //Loop until input is valid a1, b1, c2, etc...
            //             while (!isInputValid(coord!) || !s.isValidSudoku())
            //             {
            //                 //Prompt input cell
            //                 Console.Write("\n Enter coordinates (sample input: 'a1', 'I9')\n> ");
            //                 coord = Console.ReadLine();
            //                 //Validate input cell
            //                 if (!isInputValid(coord!))
            //                 {
            //                     Console.WriteLine("Invalid input");
            //                     Thread.Sleep(500);
            //                     s.displayBoard(); //Display board
            //                 }
            //                 else
            //                 {
            //                     //Reset input
            //                     numb = -1;
            //                     //Check if cell input is empty (from setBoard)
            //                     if (!s.isEmpty(s.getRow(coord!), s.getCol(coord!)))
            //                         Console.WriteLine("This cell is not empty. Try again!");
            //                     else
            //                     {
            //                         //Prompt for a number to insert into the playBoard
            //                         Console.Write("Enter your number here\n> ");
            //                         //Validate number
            //                         while (numb < 0 || numb > 9)
            //                         {
            //                             numb = getInput(@"^[1-9]$");
            //                             if (numb == -1)
            //                                 Console.Write("Invalid input. Try again:\n> ");
            //                         }
            //                         //Insert number
            //                         s.setInt(s.getRow(coord!), s.getCol(coord!), numb);
            //                         //Display board after inserted
            //                         s.displayBoard();
            //                         if (s.isValidSudoku())
            //                         {
            //                             Console.WriteLine("You solved this puzzle.");
            //                             Thread.Sleep(1000);
            //                             break;
            //                         }
            //                     }
            //                 }

            //             }
            //             break;
            //         case 2: //Computer plays game
            //             s.displayBoard();
            //             if (!s.solve())
            //                 Console.WriteLine("There is no solution");
            //             else
            //             {
            //                 s.displayBoard();
            //                 Console.WriteLine("It is all solved!");
            //             }
            //             Thread.Sleep(1000);
            //             break;
            //         case 3: //Exit
            //             Console.WriteLine("Exiting...");
            //             break;
            //         default:
            //             Console.WriteLine("Invalid input. Try again");
            //             Thread.Sleep(500);
            //             break;
            //     }
            // }
        }

        //Method to get user input depends on pattern
        public static int getInput(string pattern)
        {
            string? input = Console.ReadLine();
            //Regex accepts 1 to 3 only
            Regex rx = new Regex(pattern);
            //Check if matches, print out result
            if (!rx.IsMatch(input!))
                return -1;

            return Int32.Parse(input!);
        }

        //Method to check cell input is valid (a1, b2, c9, i9, etc)
        public static bool isInputValid(string input)
        {
            //Regex accepts a to j or A to J and 1 to 9
            Regex rx = new Regex(@"^[a-iA-I][1-9]$");
            //Check if matches, return result
            return rx.IsMatch(input) ? true : false;
        }
    }
}