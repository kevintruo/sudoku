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

        public bool isValidSudoku()
        {
            HashSet<int> r = new HashSet<int>();
            HashSet<int> c = new HashSet<int>();
            HashSet<int> sb = new HashSet<int>();

            int sbRow = -1, sbColumn = 0;

            for (int i = 0; i < playBoard.GetLength(0); i++)
            {
                r.Clear();
                c.Clear();
                sb.Clear();

                for (int j = 0; j < playBoard.GetLength(1); j++)
                {
                    // Checks if no repetition exists in first row for  i = 0
                    if (playBoard[i, j] != '.' && !r.Add(playBoard[i, j]))
                        return false;

                    // Checks if no repetition exists in first column for  i = 0
                    if (playBoard[j, i] != '.' && !c.Add(playBoard[j, i]))
                        return false;

                    sbRow = i;
                    sbColumn = (3 * i) % 9 + j % 3;

                    if (sbRow < 3)
                        sbRow = 0;
                    else if (sbRow < 6)
                        sbRow = 3;
                    else
                        sbRow = 6;

                    sbRow += j / 3;

                    // Checks if no repetition exists in first subbox for  i = 0
                    if (playBoard[sbRow, sbColumn] != '.' && !sb.Add(playBoard[sbRow, sbColumn]))
                        return false;
                }
            }

            return true;
        }
        
        //Method to reset play board
        public void resetPlayBoard(){
            this.playBoard = new int[,]{};
        }
    }
}