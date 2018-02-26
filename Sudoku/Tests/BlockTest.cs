using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Sudoku.GameLogic;

namespace Sudoku.Tests
{
    [TestFixture]
    public class BlockTest
    {
        private readonly Block _block;

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

        [Test]
        public void CorrectValuesReturnedForBlock()
        {
            var values = _block.GetValuesInBlock();
            Assert.IsTrue(values.Distinct().OrderBy(v => v).SequenceEqual(new List<int> { 0, 2, 4 }));
        }
    }
}
