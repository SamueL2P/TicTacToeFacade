using TicTacToeFacade.Models;

namespace TicTacToeFacade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 =  new Player() { Name = "Sam" , Mark = Types.MarkType.X };
            Player player2 =  new Player() { Name = "Sreerag" , Mark = Types.MarkType.O };

            Board board = new Board();
            Game game = new Game(player1 , player2 , board );
            game.PlayGame();
        }
    }
}
