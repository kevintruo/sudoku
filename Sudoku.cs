namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Sudoku
    {
        private int[,] board;

        //Constructor 
        public Sudoku(int[,] board)
        {
            this.board = board;
        }

        //Get, set
        public int[,] Board { get => board; set => board = value; }

        //Method to display the main menu
        public void displayMainMenu(){
            //Commented out for testing Console.Clear();
            Console.Write("\nWelcome to the Soduku project!\n1. Play game\n2. Play for me\n3. Exit\n> ");
        }

        //Method that display the board
        public void displayBoard(){
            //Traverse the board
            for(int i = 0; i < board.GetLength(0); i++){
                //Draw a horizontal line every third time 
                if(i % 3 == 0) Console.WriteLine("  -------------------------");

                for(int j = 0; j < board.GetLength(1); j++){
                    //Add number from 1 to 9 at the start of every row
                    if(j == 0) Console.Write(i + 1 + " ");
                    //Draw a vertical line every third time
                    if(j % 3 == 0) Console.Write("| ");
                    //Insert "_" instead of 0, and change the colour to dark yellow for better visibility
                    if(board[i,j] == 0) {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("_ ", Console.ForegroundColor);
                        Console.ResetColor();
                    }
                    //Write provided numebers
                    else Console.Write(board[i,j] + " ");
                }
                //End every row with |
                Console.Write("|\n");
            }
            //Bottom border
            Console.WriteLine("  -------------------------");
            //Add letter from A to J at the end of every column
            Console.WriteLine("    A B C   D E F   G H J ");
        }

        //Method to check if the board number is from 1 to 9 only
        public bool isBoardValid(int[,] board){
            foreach(int i in board)
                if(i < 0 || i > 9)
                    return false;
            return true;
        }
    }
}