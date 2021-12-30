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
            //Sudoku obj
            Sudoku s = new Sudoku();

            //Declare variables
            int main = -1, numb = -1, diff = -1;
            string? coord = "";
            //Loop through menus
            while (diff != 4)
            {
                s.displayDifficulty();
                diff = getInput(@"^[1-4]$");
                while (main != 3 && s.setBoardDiff(diff))
                {
                    if (diff == 4)
                        return;
                    s.displayMainMenu();
                    main = getInput(@"^[1-3]$");
                    switch (main)
                    {
                        case 1:
                            while (!isInputValid(coord!) || !s.isValidSudoku())
                            {
                                //Prompt input cell
                                Console.Write("\n Enter coordinates (sample input: 'a1', 'I9', 'x' to back to menu)\n> ");
                                coord = Console.ReadLine();
                                if(coord == "x" || coord == "X")
                                    break;
                                //Validate input cell
                                if (!isInputValid(coord!))
                                {
                                    Console.WriteLine("Invalid input");
                                }
                                else
                                {
                                    //Reset input
                                    numb = -1;
                                    //Check if cell input is empty (from setBoard)
                                    if (!s.isEmpty(s.getRow(coord!), s.getCol(coord!)))
                                        Console.WriteLine("This cell is not empty. Try again!");
                                    else
                                    {
                                        //Prompt for a number to insert into the playBoard
                                        Console.Write("Enter your number here\n> ");
                                        //Validate number
                                        while (numb < 0 || numb > 9)
                                        {
                                            numb = getInput(@"^[1-9]$");
                                            if (numb == -1)
                                                Console.Write("Invalid input. Try again:\n> ");
                                        }
                                        //Insert number
                                        s.setInt(s.getRow(coord!), s.getCol(coord!), numb);
                                        //Display board after inserted
                                        Console.Clear();
                                        s.displayBoard();
                                        if (s.isValidSudoku())
                                        {
                                            Console.Write("You solved this puzzle. Enter any keys to continue: ");
                                            Console.ReadLine();
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                        case 2:
                            if (!s.solve())
                            {
                                Console.WriteLine("There is no solution");
                            }
                            else
                            {
                                Console.WriteLine();
                                s.displayBoard();
                                Console.Write("Enter any keys to continue: ");
                                Console.ReadLine();
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid board");
                            break;
                    }
                }
                main = -1;
            }
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