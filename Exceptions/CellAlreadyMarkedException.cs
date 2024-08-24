using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeFacade.Exceptions
{
    public class CellAlreadyMarkedException:Exception
    {
        public CellAlreadyMarkedException(string message):base(message) 
        {
            
        }
    }
}
