using System;
using System.Collections.Generic;

namespace Sudoku.GameLogic
{
    public interface IGameBoard
    {
        Block[,] Board { get; set; }
        void WriteBoard();
        bool CheckValueExistsInBoardRow(int blockRow, int squareRow, int value);
        bool CheckValueExistsInBoardColumn(int blockCol, int squareCol, int value);
    }

    public class GameBoard : IGameBoard
    {
        public Block[,] Board { get; set; }
        private const int BlocksPerSide = 3;

        public GameBoard()
        {
            Board = SetupBoard();
        }

        public bool CheckValueExistsInBoardRow(int blockRow, int squareRow, int value)
        {
            foreach (var block in GetBlocksByRow(blockRow))
            {
                foreach (var square in block.GetValuesInRow(squareRow))
                {
                    if (square.Equals(value))
                        return true;
                }
            }

            return false;
        }

        public bool CheckValueExistsInBoardColumn(int blockCol, int squareCol, int value)
        {
            foreach (var block in GetBlocksByColumn(blockCol))
            {
                foreach (var square in block.GetValuesInColumn(squareCol))
                {
                    if (square.Equals(value))
                        return true;
                }
            }

            return false;
        }

        public void WriteBoard()
        {
            Console.Clear();

            for (var blockRow = 0; blockRow < BlocksPerSide; blockRow++)
            {
                for (var squareRow = 0; squareRow < BlocksPerSide; squareRow++)
                {
                    var rowValues = new List<int>();
                    for (var blockCol = 0; blockCol < BlocksPerSide; blockCol++)
                    {
                        rowValues.AddRange(Board[blockRow, blockCol].GetValuesInRow(squareRow));
                    }

                    Console.WriteLine($"{string.Join("|", rowValues)}|");
                }
            }
        }

        private IEnumerable<Block> GetBlocksByRow(int blockRow)
        {
            var blocks = new List<Block>();
            for (var i = 0; i < BlocksPerSide; i++)
            {
                blocks.Add(Board[blockRow, i]);
            }

            return blocks;
        }

        private IEnumerable<Block> GetBlocksByColumn(int blockCol)
        {
            var blocks = new List<Block>();
            for (var i = 0; i < BlocksPerSide; i++)
            {
                blocks.Add(Board[i, blockCol]);
            }

            return blocks;
        }

        private static Block[,] SetupBoard()
        {
            var board = new Block[BlocksPerSide, BlocksPerSide];

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
