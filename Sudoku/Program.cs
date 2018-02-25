using Sudoku.GameLogic;
using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            board.WriteBoard();

            var game = new Game(board);

            Console.ReadLine();
        }
    }
}
