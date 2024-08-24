using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeFacade.Exceptions;

namespace TicTacToeFacade.Models
{
    internal class Game
    {
        public Board Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public ResultAnalyzer ResultAnalyzer { get; set; }

        public Player CurrentPlayer { get; set; }

        public Game(Player player1 , Player player2 , Board board)
        {
            Board = board;
            Player1 = player1;
            Player2 = player2;
            CurrentPlayer = player1;
            ResultAnalyzer = new ResultAnalyzer { Board = board };


        }

        public void PlayGame()
        {
            while (ResultAnalyzer.Result == Types.ResultType.PROGRESS && !Board.IsBoardFull())
            {
                Board.DisplayBoard();
                Console.WriteLine($"\nCurrent Player {CurrentPlayer.Name} with mark {CurrentPlayer.Mark}");
                
                Console.WriteLine("Enter location from 1 to 9:");
                int choice;
                bool validInput = int.TryParse(Console.ReadLine(), out choice);

                if (!validInput || choice < 1 || choice > 9)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 9.");
                    continue;
                }

                try
                {
                    Board.SetCellMark(choice, CurrentPlayer.Mark);
                    ResultAnalyzer.AnalyzeResult();

                    if (ResultAnalyzer.Result != Types.ResultType.PROGRESS)
                    {
                        break;
                    }

                    CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
                }
                catch (CellAlreadyMarkedException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            Board.DisplayBoard();

            if (ResultAnalyzer.Result == Types.ResultType.WIN)
            {
                Console.WriteLine($"{CurrentPlayer.Name} has won!");
            }
            else if (ResultAnalyzer.Result == Types.ResultType.DRAW)
            {
                Console.WriteLine("It's a draw!");
            }
        }


    }
}
