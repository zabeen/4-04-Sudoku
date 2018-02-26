using NUnit.Framework;
using Sudoku.GameLogic;

namespace Sudoku.Tests
{
    [TestFixture]
    public class BoardTest
    {
        private IBoard _board;

        public BoardTest()
        {
            _board = new Board();
        }

        [Test]
        public void RowCheckReturnsTrueWhenValueExists()
        {
            Assert.IsTrue(_board.BoardRowContains(2, 0, 5));
        }

        [Test]
        public void RowCheckReturnsFalseWhenValueDoesNotExist()
        {
            Assert.IsFalse(_board.BoardRowContains(1, 1, 5));
        }

        [Test]
        public void ColumnCheckReturnsTrueWhenValueExists()
        {
            Assert.IsTrue(_board.BoardColumnContains(0, 0, 6));
        }

        [Test]
        public void ColumnCheckReturnsFalseWhenValueDoesNotExist()
        {
            Assert.IsFalse(_board.BoardColumnContains(1, 2, 9));
        }
    }
}
