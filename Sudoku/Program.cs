using Sudoku.GameLogic;
using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new SudokuBoard();
            board.WriteBoard();

            var game = new Solution(board);

            Console.ReadLine();
        }
    }
}
