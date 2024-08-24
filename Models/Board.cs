using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeFacade.Exceptions;
using TicTacToeFacade.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TicTacToeFacade.Models
{
    internal class Board
    {
        public Cell[] cells = new Cell[9];

        public Board()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = new Cell();
                cells[i].SetMark(MarkType.EMPTY); 
            }
        }

        public bool IsBoardFull()
        {
            foreach (var cell in cells)
            {
                if(cell.isEmpty() == true)
                    return false;
                
            }
            return true;
        }

        public void SetCellMark(int location , MarkType mark)
        {
            if (location < 1 || location > cells.Length + 1)
                throw new ArgumentOutOfRangeException(nameof(location), "Invalid cell location. Please choose a number between 1 and 9.");
            Cell cell = cells[location - 1];
            if (cell.GetMark() != MarkType.EMPTY)
                throw new CellAlreadyMarkedException("Cell Already Marked");
            cell.SetMark(mark); 
            
        }
        public void DisplayBoard()
        {
            string GetMarkForDisplay(int index, Cell cell)
            {
                return cell.GetMark() == MarkType.EMPTY ? (index + 1).ToString() : cell.GetMark().ToString();
            }

            Console.WriteLine($"\n {GetMarkForDisplay(0, cells[0])} | {GetMarkForDisplay(1, cells[1])} | {GetMarkForDisplay(2, cells[2])} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {GetMarkForDisplay(3, cells[3])} | {GetMarkForDisplay(4, cells[4])} | {GetMarkForDisplay(5, cells[5])} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {GetMarkForDisplay(6, cells[6])} | {GetMarkForDisplay(7, cells[7])} | {GetMarkForDisplay(8, cells[8])} ");
        }

    }
}
