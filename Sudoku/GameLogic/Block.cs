using System.Collections.Generic;

namespace Sudoku.GameLogic
{
    public class Block
    {
        public IEnumerable<int> Values => GetValuesInBlock();

        private int[,] _block;

        public Block(int[,] values)
        {
            _block = values;
        }

        public int GetSquareValue(Coordinates square)
        {
            return _block[square.Row, square.Column];
        }

        public void SetSquareValue(Coordinates square, int value)
        {
            _block[square.Row, square.Column] = value;
        }

        public IEnumerable<int> GetValuesInRow(int row)
        {
            var values = new List<int>();
            for (var i = 0; i < _block.GetLength(1); i++)
            {
                values.Add(_block[row, i]);
            }

            return values;
        }

        public IEnumerable<int> GetValuesInColumn(int col)
        {
            var values = new List<int>();
            for (var i = 0; i < _block.GetLength(0); i++)
            {
                values.Add(_block[i, col]);
            }

            return values;
        }

        private IEnumerable<int> GetValuesInBlock()
        {
            var values = new List<int>();
            for (var i = 0; i < _block.GetLength(0); i++)
            {
                for (var j = 0; j < _block.GetLength(1); j++)
                {
                    values.Add(_block[i,j]);
                }
            }

            return values;
        }
    }
}
