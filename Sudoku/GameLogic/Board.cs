using System;
using System.Collections.Generic;

namespace Sudoku.GameLogic
{
    public interface IBoard
    {
        int BlocksPerSide { get; }
        Block GetBlock(Coordinates blockCoordinates);
        void WriteBoard();
        bool CheckValueExistsInBoardRow(int blockRow, int squareRow, int value);
        bool CheckValueExistsInBoardColumn(int blockCol, int squareCol, int value);
        IBoard CopyBoard();
    }

    public class Board : IBoard
    {
        public int BlocksPerSide { get; } = 3;
        private Block[,] _board;  
    
        public Board()
        {
            _board = SetupBoard();
        }

        public Block GetBlock(Coordinates blockCoordinates)
        {
            return _board[blockCoordinates.Row, blockCoordinates.Column];
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
                        rowValues.AddRange(_board[blockRow, blockCol].GetValuesInRow(squareRow));
                    }

                    Console.WriteLine($"{string.Join("|", rowValues)}|");
                }
            }
        }

        public IBoard CopyBoard()
        {
            var board = new Board();
            board.SetupBoard();
            return board;
        }

        private IEnumerable<Block> GetBlocksByRow(int blockRow)
        {
            var blocks = new List<Block>();
            for (var i = 0; i < BlocksPerSide; i++)
            {
                blocks.Add(_board[blockRow, i]);
            }

            return blocks;
        }

        private IEnumerable<Block> GetBlocksByColumn(int blockCol)
        {
            var blocks = new List<Block>();
            for (var i = 0; i < BlocksPerSide; i++)
            {
                blocks.Add(_board[i, blockCol]);
            }

            return blocks;
        }

        private Block[,] SetupBoard()
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
