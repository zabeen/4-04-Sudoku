using NUnit.Framework;
using Sudoku.GameLogic;

namespace Sudoku.Tests
{
    [TestFixture]
    public class BoardTest
    {
        private ISudokuBoard _board;

        public BoardTest()
        {
            _board = new SudokuBoard();
        }

        [Test]
        public void RowCheckReturnsTrueWhenValueExists()
        {
            Assert.IsTrue(_board.CheckValueExistsInBoardRow(2, 0, 5));
        }

        [Test]
        public void RowCheckReturnsFalseWhenValueDoesNotExist()
        {
            Assert.IsFalse(_board.CheckValueExistsInBoardRow(1, 1, 5));
        }

        [Test]
        public void ColumnCheckReturnsTrueWhenValueExists()
        {
            Assert.IsTrue(_board.CheckValueExistsInBoardColumn(0, 0, 6));
        }

        [Test]
        public void ColumnCheckReturnsFalseWhenValueDoesNotExist()
        {
            Assert.IsFalse(_board.CheckValueExistsInBoardColumn(1, 2, 9));
        }
    }
}
