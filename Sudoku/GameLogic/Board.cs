using System;
using System.Text;

namespace Sudoku.GameLogic
{
    public class Board
    {
        public int[,] CurrentGame => SetupBoard();

        public void WriteBoard()
        {
            Console.Clear();

            for (var i = 0; i < 9; i++)
            {
                var seperator = new StringBuilder();
                for (var j = 0; j < 9; j++)
                {
                    var value = CurrentGame[i, j].ToString().Replace("0", " ");
                    Console.Write($"| {value} ");
                    seperator.Append("----");
                }
                Console.WriteLine("|");
                Console.WriteLine(seperator);
            }
        }

        private int[,] SetupBoard()
        {
            var board = new int[9, 9];

            board[0, 5] = 2;
            board[0, 6] = 1;

            board[1, 2] = 4;
            board[1, 5] = 8;
            board[1, 6] = 7;

            board[2, 1] = 2;
            board[2, 3] = 3;
            board[2, 6] = 9;

            board[3, 0] = 6;
            board[3, 2] = 2;
            board[3, 5] = 3;
            board[3, 7] = 4;

            board[5, 1] = 5;
            board[5, 3] = 6;
            board[5, 6] = 3;
            board[5, 8] = 1;

            board[6, 2] = 3;
            board[6, 5] = 5;
            board[6, 7] = 8;

            board[7, 2] = 8;
            board[7, 3] = 2;
            board[7, 6] = 5;

            board[8, 2] = 9;
            board[8, 3] = 7;

            return board;
        }
    }
}
