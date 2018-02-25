using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.GameLogic
{
    public interface IBoard
    {
        Block[,] CurrentGame { get; set; }
        void WriteBoard();
    }

    public class Board : IBoard
    {
        public Block[,] CurrentGame { get; set; }
        private const int BlocksPerRow = 3;
        private const int SquaresPerRow = 9;

        public Board()
        {
            CurrentGame = SetupBoard();
        }

        public void WriteBoard()
        {
            Console.Clear();

            for (var blockRow = 0; blockRow < BlocksPerRow; blockRow++)
            {
                for (var squareRow = 0; squareRow < BlocksPerRow; squareRow++)
                {
                    var rowValues = new List<int>();
                    for (var blockCol = 0; blockCol < BlocksPerRow; blockCol++)
                    {
                        rowValues.AddRange(CurrentGame[blockRow, blockCol].GetValuesInRow(squareRow));
                    }

                    Console.WriteLine($"{string.Join("|", rowValues)}|");
                }
            }
        }

        private static Block[,] SetupBoard()
        {
            var board = new Block[BlocksPerRow, BlocksPerRow];

            board[0, 0] = new Block(new[,] { { 0, 0, 0 }, { 0, 0, 4 }, { 0, 2, 0 } });
            board[0, 1] = new Block(new[,] { { 0, 0, 2 }, { 0, 0, 8 }, { 3, 0, 0 } });
            board[0, 2] = new Block(new[,] { { 1, 0, 0 }, { 7, 0, 0 }, { 9, 0, 0 } });
            board[1, 0] = new Block(new[,] { { 6, 0, 2 }, { 0, 0, 0 }, { 0, 5, 0 } });
            board[1, 1] = new Block(new[,] { { 0, 0, 3 }, { 0, 0, 0 }, { 6, 0, 0 } });
            board[1, 2] = new Block(new[,] { { 0, 4, 0 }, { 0, 0, 0 }, { 3, 0, 1 } });
            board[2, 0] = new Block(new[,] { { 0, 0, 3 }, { 0, 0, 8 }, { 0, 0, 9 } });
            board[2, 1] = new Block(new[,] { { 0, 0, 5 }, { 2, 0, 0 }, { 7, 0, 0 } });
            board[2, 2] = new Block(new[,] { { 0, 8, 0 }, { 5, 0, 0 }, { 0, 0, 0 } });

            return board;
        }
    }
}
