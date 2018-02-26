using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.GameLogic
{
    public class Block
    {
        private int[,] _block;

        public Block(int[,] values)
        {
            _block = values;
        }

        public bool CheckValueExistsInBlock(int value)
        {
            for (var i = 0; i < _block.GetLength(0); i++)
            {
                for (var j = 0; j < _block.GetLength(1); j++)
                {
                    if (_block[i, j].Equals(value))
                        return true;
                }
            }

            return false;
        }

        public void SetSquareValue(int row, int col, int value)
        {
            _block[row, col] = value;
        }

        public IEnumerable<int> GetValuesInRow(int row)
        {
            var values = new int[_block.GetLength(1)];
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = _block[row, i];
            }

            return values;
        }

        public IEnumerable<int> GetValuesInColumn(int col)
        {
            var values = new int[_block.GetLength(0)];
            for (var i = 0; i < values.Length; i++)
            {
                values[i] = _block[i, col];
            }

            return values;
        }
    }
}
