using NUnit.Framework;
using Sudoku.GameLogic;

namespace Sudoku.Tests
{
    [TestFixture]
    public class BlockTest
    {
        private Block _block;

        public BlockTest()
        {
            _block = new Block(new[,] { { 0, 0, 0 }, { 0, 0, 4 }, { 0, 2, 0 } });
        }

        [Test]
        public void SquareCheckReturnsTrueWhenValueExists()
        {
            Assert.IsTrue(_block.CheckValueExistsInBlock(2));
        }

        [Test]
        public void SquareCheckReturnsFalseWhenValueDoesNotExist()
        {
            Assert.IsFalse(_block.CheckValueExistsInBlock(9));
        }
    }
}
