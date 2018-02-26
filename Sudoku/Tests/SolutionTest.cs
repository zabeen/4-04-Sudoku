using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Sudoku.GameLogic;

namespace Sudoku.Tests
{
    [TestFixture]
    public class SolutionTest
    {
        private readonly ISudokuBoard _board;

        public SolutionTest()
        {
            _board = new SudokuBoard();
            var solution = new Solution(_board);
            solution.SolveBoard();
        }

        [Test]
        public void EverySquareInBlockHasUniqueNumber()
        {
            for (var row = 0; row < 3; row++)
            {
                for (var col = 0; col < 3; col++)
                {
                    var blockValues = _board.GetBlock(new Coordinates(row,col)).GetValuesInBlock();
                    Assert.IsFalse(blockValues.GroupBy(v => v).Any(g => g.Count() > 1));
                }
            }
        }

        [Test]
        public void EverySquareInBoardRowHasUniqueNumber()
        {
            
        }
    }
}
