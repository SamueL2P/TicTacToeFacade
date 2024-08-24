using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeFacade.Types;

namespace TicTacToeFacade.Models
{
    internal class ResultAnalyzer
    {
        public Board Board { get; set; }

        public ResultType Result {  get; set; }

        public ResultAnalyzer()
        {
            Result = ResultType.PROGRESS;
            
        }

        public void HorizontalWinCheck()
        {
           if(((( Board.cells[0].GetMark() == Board.cells[1].GetMark() ) && (Board.cells[1].GetMark() == Board.cells[2].GetMark())) && Board.cells[0].GetMark() != MarkType.EMPTY) ||
            (((Board.cells[3].GetMark() == Board.cells[4].GetMark()) && (Board.cells[4].GetMark() == Board.cells[5].GetMark())) && Board.cells[3].GetMark() != MarkType.EMPTY) ||
            (((Board.cells[6].GetMark() == Board.cells[7].GetMark()) && (Board.cells[7].GetMark() == Board.cells[8].GetMark())) && Board.cells[6].GetMark() != MarkType.EMPTY))
            {
                Result = ResultType.WIN;
            }
        }

        public void VerticalWinCheck()
        {
            if ((((Board.cells[0].GetMark() == Board.cells[3].GetMark()) && (Board.cells[3].GetMark() == Board.cells[6].GetMark())) && Board.cells[0].GetMark() != MarkType.EMPTY) ||
                (((Board.cells[1].GetMark() == Board.cells[4].GetMark()) && (Board.cells[4].GetMark() == Board.cells[7].GetMark())) && Board.cells[1].GetMark() != MarkType.EMPTY) ||
                (((Board.cells[2].GetMark() == Board.cells[5].GetMark()) && (Board.cells[5].GetMark() == Board.cells[8].GetMark())) && Board.cells[2].GetMark() != MarkType.EMPTY))
            {
                Result = ResultType.WIN;
            }
        }

        public void DiagonalWinCheck()
        {
            if ((((Board.cells[0].GetMark() == Board.cells[4].GetMark()) && (Board.cells[4].GetMark() == Board.cells[8].GetMark())) && Board.cells[0].GetMark() != MarkType.EMPTY) ||
                (((Board.cells[2].GetMark() == Board.cells[4].GetMark()) && (Board.cells[4].GetMark() == Board.cells[6].GetMark())) && Board.cells[2].GetMark() != MarkType.EMPTY))
            {
                Result = ResultType.WIN;
            }
        }

        public ResultType AnalyzeResult()
        {
            HorizontalWinCheck();
            VerticalWinCheck();
            DiagonalWinCheck();

            if (Result != ResultType.WIN && Board.IsBoardFull())
            {
                Result = ResultType.DRAW;
            }

            return Result;
        }

    }
}
