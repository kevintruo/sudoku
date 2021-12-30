namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Sudoku
    {
        //CRUD board
        private int[,] playBoard;

        //Reference board, no CRUD
        private int[,] setBoard;

        private int[,] easy = new int[,] {
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

        //Test board
        private int[,] medium = new int[,] {
                {9,8,4,7,3,5,0,0,0},
                {0,0,7,0,0,0,0,0,0},
                {0,0,3,0,0,0,5,0,7},
                {0,0,0,9,4,0,0,1,8},
                {0,4,9,1,0,2,0,0,0},
                {1,3,0,0,0,0,0,4,0},
                {0,0,0,2,0,0,0,7,0},
                {0,7,0,4,0,8,0,0,3},
                {4,0,1,0,6,7,0,5,0}
        };

        private int[,] hard = new int[,] {
                {0,6,3,0,0,0,0,2,0},
                {0,0,0,8,0,0,9,0,0},
                {8,0,0,6,7,0,0,0,5},
                {3,8,0,0,0,0,6,9,0},
                {0,1,0,2,0,4,0,0,0},
                {4,0,0,0,0,0,8,0,0},
                {7,3,0,0,1,0,0,0,0},
                {0,4,0,0,0,3,0,0,1},
                {6,0,0,0,0,0,0,0,0}
        };

        //Constructor
        public Sudoku(){
            playBoard = new int[,]{};
            setBoard = new int[,]{};
        }

        //Get, set
        public int[,] Board { get => playBoard; set => playBoard = value; }

        //Method that display the board
        public void displayBoard()
        {
            //Traverse the board
            for (int i = 0; i < playBoard.GetLength(0); i++)
            {
                //Draw a horizontal line every third time 
                if (i % 3 == 0) Console.WriteLine("  -------------------------");

                for (int j = 0; j < playBoard.GetLength(1); j++)
                {
                    //Add number from 1 to 9 at the start of every row
                    if (j == 0) Console.Write(i + 1 + " ");
                    //Draw a vertical line every third time
                    if (j % 3 == 0) Console.Write("| ");
                    //Insert "_" or the inserted number instead of 0, and change the colour to dark yellow for better visibility
                    if (isEmpty(i, j)) //Check if the cell from setBoard is empty
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        //Write _ or inserted number in yellow
                        if (playBoard[i, j] == 0)
                            Console.Write("_ ", Console.ForegroundColor);
                        else
                            Console.Write(playBoard[i, j] + " ", Console.ForegroundColor);
                        Console.ResetColor();
                    }
                    //Write provided numebers
                    else Console.Write(playBoard[i, j] + " ");
                }
                //End every row with |
                Console.Write("|\n");
            }
            //Bottom border
            Console.WriteLine("  -------------------------");
            //Add letter from A to J at the end of every column
            Console.WriteLine("    A B C   D E F   G H I ");
        }

        //Method to check if the board number is from 1 to 9 only
        public bool isBoardValid(int[,] board)
        {
            foreach (int i in board)
                if (i < 0 || i > 9)
                    return false;
            return true;
        }

        //Method to display the main menu
        public void displayMainMenu()
        {
            Console.Write("\n1. Play game\n2. Let the computer play for me\n3. Back to select difficulty\n> ");
        }

        //Method to select diffculty of the board
        public void displayDifficulty()
        {
            Console.Clear();
            Console.Write("\nWelcome to the Soduku project!\nSelect your diffculty:\n1: Easy\n2: Medium\n3: Hard\n4: Exit (CTRL + C to force exit anytime)\n> ");
        }

        //Method to get column coordinate
        public int getCol(string input)
        {
            return input != "" ? char.ToUpper(input.ToCharArray()[0]) - 'A' : 0;
        }

        //Method to get row coordinate
        public int getRow(string input)
        {
            return input != "" ? input.ToCharArray()[1] - '1' : 0;
        }

        //Check if setBoard is empty
        public bool isEmpty(int row, int col)
        {
            if (setBoard[row, col] == 0)
                return true;
            return false;
        }

        //Return numb from playBoard
        public int getInt(int row, int col)
        {
            return playBoard[row, col];
        }

        //Set numb to playBoard
        public void setInt(int row, int col, int input)
        {
            playBoard[row, col] = input;
        }

        //Check if sudoku board is valid
        public bool isValidSudoku()
        {
            //Created hashset
            HashSet<int> row = new HashSet<int>();
            HashSet<int> col = new HashSet<int>();
            HashSet<int> subSquare = new HashSet<int>();

            int sqRow = -1, sqCol = 0;

            for (int i = 0; i < playBoard.GetLength(0); i++)
            {
                row.Clear();
                col.Clear();
                subSquare.Clear();

                for (int j = 0; j < playBoard.GetLength(1); j++)
                {
                    // Checks if no repetition exists for row 
                    if (playBoard[i, j] != 0 && !row.Add(playBoard[i, j]))
                        return false;

                    // Checks if no repetition exists for column
                    if (playBoard[j, i] != 0 && !col.Add(playBoard[j, i]))
                        return false;

                    //Determine x,y for the subSquare traversal
                    sqRow = i;
                    sqCol = (3 * i) % 9 + j % 3;

                    if (sqRow < 3)
                        sqRow = 0;
                    else if (sqRow < 6)
                        sqRow = 3;
                    else
                        sqRow = 6;

                    sqRow += j / 3;

                    //Checks if no repetition exists for subSquare
                    if (playBoard[sqRow, sqCol] != '.' && !subSquare.Add(playBoard[sqRow, sqCol]))
                        return false;
                }
            }
            return true;
        }
        
        //Method to check if row, column and subSquare contains num
        public bool containNum (int row, int col, int num){
            //Check if row contains num
            for(int i = 0; i < playBoard.GetLength(0); i++)
                if(playBoard[row, i] == num)
                    return false;

            //Check if column contains num
            for (int j = 0; j < playBoard.GetLength(0); j++)
                if(playBoard[j, col] == num)
                    return false;

            //Check if subSquare contains numb
            //Determine starting row and column numbers
            int sqRow = row - row % 3;
            int sqCol = col - col % 3;
            for(int x = sqRow; x < sqRow + 3; x++)
                for(int y = sqCol; y < sqCol + 3; y++)
                    if(playBoard[sqRow, sqCol] == num)
                        return false;
            
            return true;
        }

        //Method to solve sudoku
        public bool solve(){
            int row = -1, col = -1;
            bool isEmpty = true;
            //Look for empty cell
            for(int i = 0; i < playBoard.GetLength(0); i++){
                for(int j = 0; j < playBoard.GetLength(1); j++){
                    if(playBoard[i, j] == 0) {
                        //Set row and col, as well as isEmpty
                        row = i;
                        col = j;
                        isEmpty = false;
                        break;
                    }
                }
                //If there is empty cell, break and recurse later
                if(!isEmpty) break;
            }
            
            //No empty cells
            if(isEmpty) return true;

            //Find value
            for(int num = 1; num <= playBoard.GetLength(0); num++) {
                //Make sure num does not contain in the row, column, subSquare
                if(containNum(row, col, num)){
                    //Set cell
                    playBoard[row, col] = num;
                    //Recurse
                    if(solve()) 
                        return true;
                    else //Backtrack
                        playBoard[row, col] = 0;
                }
            }
            return false;
        }

        public int[,] getSetBoard(){
            return this.setBoard;
        }

        public bool setBoardDiff(int diff){
            Console.Clear();
            switch(diff){
                case 1: 
                    Console.WriteLine("Difficulty: Easy");
                    cloneBoard(easy);
                    break;
                case 2:
                    Console.WriteLine("Difficulty: Medium");
                    cloneBoard(medium);
                    break;
                case 3:
                    Console.WriteLine("Difficulty: Hard");
                    cloneBoard(hard);
                    break;
                case 4:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid diffculty level");
                    return false;
            }
            return true;
        }

        public void cloneBoard(int[,] board){
            if(!isBoardValid(board)){
                Console.WriteLine("Invalid board");
                return;
            }
            this.playBoard = (int[,]) board.Clone();
            this.setBoard = (int[,]) board.Clone();
            displayBoard();
        }
    }
}