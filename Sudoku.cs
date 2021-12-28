namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Sudoku
    {
        //CRUD board
        private int[,] playBoard;

        //Reference board, no CRUD
        private int[,] setBoard;

        //Constructor 
        public Sudoku(int[,] board)
        {
            this.playBoard = (int[,]) board.Clone();
            this.setBoard = (int[,]) board.Clone();
        }

        //Get, set
        public int[,] Board { get => playBoard; set => playBoard = value; }

        //Method that display the board
        public void displayBoard()
        {
            //Clear console
            Console.Clear();
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
            Console.Clear();
            Console.Write("Welcome to the Soduku project!\n1. Play game\n2. Let the computer play for me\n3. Exit (CTRL + C to force quit)\n> ");
        }

        //Method to display second menu
        public void displaySecondMenu()
        {
            Console.WriteLine("Loading...");
            Thread.Sleep(1000);
            Console.Clear();
            Console.Write("1. Load the board from 'board.txt'\n2. Generate a random board\n3. Back to main menu\n> ");
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

        public bool solve(){
            int row = -1, col = -1;
            bool isEmpty = true;
            for(int i = 0; i < playBoard.GetLength(0); i++){
                for(int j = 0; j < playBoard.GetLength(1); j++){
                    if(playBoard[i, j] == 0) {
                        row = i;
                        col = j;
                        isEmpty = false;
                        break;
                    }
                }
                if(!isEmpty) break;
            }
            if(isEmpty) return true;

            for(int num = 1; num <= playBoard.GetLength(0); num++) {
                if(containNum(row, col, num)){
                    playBoard[row, col] = num;
                    if(solve()) 
                        return true;
                    else
                        playBoard[row, col] = 0;
                }
            }
            return false;
        }
    }
}