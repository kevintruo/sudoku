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
            int numb1 = -1, numb2 = -1, numb = -1;
            string? coord = "";

            //While loop through
            while(numb1 != 3){
                //Display menu 
                s.displayMainMenu();
                //Get input from 1 to 3
                numb1 = getInput(@"^[1-3]$");
                //Switch statement
                switch(numb1){
                    case 1: //Play game
                        while(numb2 != 3){
                            //Display second menu 
                            s.displaySecondMenu();
                            //Get input from 1 to 3
                            numb2 = getInput(@"^[1-3]$");
                            //Switch statement
                            switch(numb2){
                                case 1: //Load the board from 'board.txt'
                                    //Check if board is valid
                                    if(!s.isBoardValid(test)){
                                        Console.WriteLine("Your board is invalid"); 
                                        Thread.Sleep(300);
                                        break;
                                    }

                                    s.displayBoard(); //Display board
                                    //Reset input
                                    coord = "";
                                    //Loop until input is valid a1, b1, c2, etc...
                                    while(!isInputValid(coord!)){
                                        Console.Write("\n Enter coordinates (sample input: 'a1', 'J9')\n> ");   
                                        coord = Console.ReadLine();
                                        if(!isInputValid(coord!))
                                            Console.WriteLine("Invalid input");
                                        else {
                                            numb = -1;
                                            Console.WriteLine("Column coord is " + s.getCol(coord!));
                                            Console.WriteLine("Row coord is " + s.getRow(coord!));
                                            Console.Write("Enter your number here\n> ");
                                            while(numb < 0 || numb > 9){ 
                                                numb = getInput(@"^[1-9]$");
                                                if(numb == -1)
                                                    Console.Write("Invalid input. Try again:\n> ");
                                            }
                                           
                                        }
                                        
                                    }
                                    break;
                                case 2: //Generate a random board
                                    s.displayBoard(); 
                                    break;
                                case 3: //Back to main menu
                                    Console.WriteLine("Going to main menu ...");
                                    Thread.Sleep(300);
                                    break;
                                default:
                                    Console.WriteLine("Invalid input. Try again");
                                    Thread.Sleep(500);
                                    break;
                            }
                        }
                        //Reset numb2
                        numb2 = -1;
                        break;
                    case 2: //Computer plays game
                        s.displaySecondMenu();
                        break;
                    case 3: //Exit
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
        public static int getInput(string pattern){
            string? input = Console.ReadLine();
            //Regex accepts 1 to 3 only
            Regex rx = new Regex(pattern); 
            //Check if matches, print out result
            if(!rx.IsMatch(input!))
                return -1;
            
            return Int32.Parse(input!);
        }

        public static bool isInputValid(string input){
            //Regex accepts a to j or A to J and 1 to 9
            Regex rx = new Regex(@"^[a-jA-J][1-9]$");
            //Check if matches, return result
            return rx.IsMatch(input) ? true : false;
        }
    }
}