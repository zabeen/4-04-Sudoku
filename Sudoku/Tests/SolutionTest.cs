using NUnit.Framework;
using NUnit.Framework.Internal;
using Sudoku.GameLogic;
using System.Linq;

namespace Sudoku.Tests
{
    [TestFixture]
    public class SolutionTest
    {
        private readonly IBoard _board;

        public SolutionTest()
        {
            _board = new Board();
            var solution = new Solution(_board);
            solution.SolveBoard();
        }

        [Test]
        public void EverySquareInEveryBlockHasUniqueNumber()
        {
            for (var row = 0; row < 3; row++)
            {
                for (var col = 0; col < 3; col++)
                {
                    var blockValues = _board.GetBlock(new Coordinates(row, col)).Values;
                    Assert.IsFalse(blockValues.GroupBy(v => v).Any(g => g.Count() > 1));
                }
            }
        }

        [Test]
        public void EverySquareInBoardRowHasUniqueNumber()
        {
            // todo
        }

        [Test]
        public void EverySquareInBoardColumnHasUniqueNumber()
        {
            // todo
        }
    }
}
