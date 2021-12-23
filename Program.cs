﻿using System;
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
            int numb = -1;
            
            //While loop through
            while(numb != 3){
                //Display menu 
                s.displayMainMenu();
                numb = getInput();
                switch(numb){
                    case 1:
                        s.displaySecondMenu();
                        break;
                    case 2:
                        s.displaySecondMenu();
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        break;
                    default: 
                        Console.WriteLine("Invalid input. Try again");
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
            Regex rx = new Regex(@"\b[1-3]\b"); 
            //Check if matches, print out result
            if(!rx.IsMatch(input!))
                return -1;
            
            return Int32.Parse(input!);
        }
    }
}