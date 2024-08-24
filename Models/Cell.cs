using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeFacade.Exceptions;
using TicTacToeFacade.Types;

namespace TicTacToeFacade.Models
{
    internal class Cell
    {
        public MarkType Mark ;

        public Cell()
        {
            Mark = MarkType.EMPTY;
        }

        public bool isEmpty()
        {
            if (Mark == MarkType.EMPTY)
                return true;
            return false;
        }

        public MarkType GetMark()
        {
            return Mark;
        }

        public void SetMark(MarkType mark)
        {
            if (Mark != MarkType.EMPTY)
                throw new CellAlreadyMarkedException("Cell Already Marked");
            Mark = mark;
        }
    }
}
