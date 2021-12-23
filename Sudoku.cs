namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Soduku
    {
        private int[,] board;

        public Soduku(int[,] board)
        {
            this.board = board;
        }

        public int[,] Board { get => board; set => board = value; }

        public void displayMainMenu(){
            Console.Clear();
        }
    }
}