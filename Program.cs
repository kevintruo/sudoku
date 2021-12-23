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
            //Test board
            int[,] test = new int[,] {
                {0,7,0,0,2,9,1,0,0}, 
                {0,0,5,0,0,0,9,6,0}, 
                {2,0,0,5,0,1,0,0,0}, 
                {8,2,0,1,0,0,7,0,3},
                {9,3,6,0,0,0,2,0,8}, 
                {0,0,7,8,3,0,0,9,6}, 
                {3,0,1,0,0,7,6,0,9}, 
                {7,0,2,9,0,0,5,0,1},
                {4,0,9,0,0,3,0,0,0}
            };

            //Sudoku obj
            Sudoku s = new Sudoku(test);

            //Declare variables
            int numb1 = -1, numb2 = -1;
            
            //While loop through
            while(numb1 != 3){
                //Display menu 
                s.displayMainMenu();
                numb1 = getInput();
                switch(numb1){
                    case 1:
                        while(numb2 != 3){
                            s.displaySecondMenu();
                            numb2 = getInput();
                            switch(numb2){
                                case 1:
                                    s.displayBoard(); 
                                    Console.Write("\n Enter coordinates (sample input: 'a1', 'J9')\n> ");
                                    Console.ReadLine();
                                    break;
                                case 2:
                                    s.displayBoard(); 
                                    break;
                                case 3:
                                    Console.WriteLine("Going to main menu ...");
                                    Thread.Sleep(300);
                                    break;
                                default:
                                    Console.WriteLine("Invalid input. Try again");
                                    Thread.Sleep(500);
                                    break;
                            }
                        }
                        numb2 = -1;
                        break;
                    case 2:
                        s.displaySecondMenu();
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        break;
                    default: 
                        Console.WriteLine("Invalid input. Try again");
                        Thread.Sleep(500);
                        break;
                }

                // //Check if board is valid
                // if(s.isBoardValid(test)) //True
                //     s.displayBoard(); //Display board
                // else //False
                //     Console.WriteLine("Your board is invalid"); //Error msg
            }
        }

        //Method to get user input from 1 to 3 only
        public static int getInput(){
            string? input = Console.ReadLine();
            //Regex accepts 1 to 3 only
            Regex rx = new Regex(@"\b[1-3]$"); 
            //Check if matches, print out result
            if(!rx.IsMatch(input!))
                return -1;
            
            return Int32.Parse(input!);
        }
    }
}