namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Sudoku
    {
        private int[,] board;

        public Sudoku(int[,] board)
        {
            this.board = board;
        }

        public int[,] Board { get => board; set => board = value; }

        //Method to display the main menu
        public void displayMainMenu(){
            Console.Clear();
            Console.Write("\nWelcome to the Soduku project!\n1. Play game\n2. Play for me\n3. Exit\n> ");
        }

        //Method that display the board
        public void displayBoard(){
            //Traverse the board
            for(int i = 0; i < board.GetLength(0); i++){
                //Draw a horizontal line every third time 
                if(i % 3 == 0) Console.WriteLine("-------------------------");

                for(int j = 0; j < board.GetLength(1); j++){
                    //Draw a vertical line every third time
                    if(j % 3 == 0) Console.Write("| ");
                    if(board[i,j] == 0) Console.Write("_ ");
                    else Console.Write(board[i,j] + " ");
                }
                Console.Write("|\n");
            }
            Console.WriteLine("-------------------------");
        }
    }
}