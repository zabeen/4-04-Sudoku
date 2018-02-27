using NUnit.Framework;
using NUnit.Framework.Internal;
using Sudoku.GameLogic;

namespace Sudoku.Tests
{
    [TestFixture]
    public class CoordinatesTest
    {
        [Test]
        public void WhenNotLastPositionInRow_OnNextColumnIncreasesByOneRowStaysSame()
        {
            const int col = 0;
            const int row = 0;
            var coord = new Coordinates(row, col);
            var next = coord.Next;

            Assert.AreEqual(next, new Coordinates(row, col + 1));
        }

        [Test]
        public void WhenLastPositionInRow_OnNextColumnBecomesZeroRowIncreasesByOne()
        {
            const int col = 2;
            const int row = 1;
            var coord = new Coordinates(row, col);
            var next = coord.Next;

            Assert.AreEqual(next, new Coordinates(row + 1, 0));
        }

        [Test]
        public void WhenLastPositionInSet_OnNextColumnAndRowBecomeZero()
        {
            const int col = 2;
            const int row = 2;
            var coord = new Coordinates(row, col);
            var next = coord.Next;

            Assert.AreEqual(next, new Coordinates(0, 0));
        }
    }
}
