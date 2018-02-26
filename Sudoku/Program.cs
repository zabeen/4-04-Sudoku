using Sudoku.GameLogic;
using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            var solution = new Solution(board);
            solution.SolveBoard();

            board.WriteBoard();

            Console.ReadLine();
        }
    }
}
