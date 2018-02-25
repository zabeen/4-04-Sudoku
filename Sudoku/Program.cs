using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku.GameLogic;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            board.WriteBoard();
            Console.ReadLine();
        }
    }
}
