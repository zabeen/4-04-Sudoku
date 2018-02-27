using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.GameLogic
{
    public struct Coordinates
    {
        public int Row { get; }
        public int Column { get; }
        public Coordinates Next => NextCoordinates();

        private const int MaxIndex = 2;

        public Coordinates(int row, int col)
        {
            Row = row;
            Column = col;
        }

        public Coordinates NextCoordinates()
        {
            var col = Column == MaxIndex ? 0 : Column + 1;
            var row = Column == MaxIndex ? Row == MaxIndex ? 0 : Row + 1 : Row;

            return new Coordinates(row, col); ;
        }
    }
}
