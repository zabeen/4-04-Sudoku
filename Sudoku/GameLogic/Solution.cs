using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Sudoku.GameLogic
{
    public class Solution
    {
        protected class Node
        {
            public Coordinates Block { get; }
            public Coordinates Square { get; }

            public Node(Coordinates block, Coordinates square)
            {
                Block = block;
                Square = square;
            }
        }

        private readonly ISudokuBoard _referenceCopy;
        private readonly ISudokuBoard _workingCopy;
        private const int SquaresTotal = 81;
        private const int MinValue = 1;
        private const int MaxValue = 9;

        public Solution(ISudokuBoard board)
        {
            _workingCopy = board;
            _referenceCopy = board.CopyBoard();
        }

        public void SolveBoard()
        {
            var blockCoordinates = new Coordinates(0, 0);
            var squareCoordinates = new Coordinates(0, 0);

            FindValues(new Node(blockCoordinates, squareCoordinates));
        }

        private bool FindValues(Node current, int counter = 0)
        {
            if (counter == SquaresTotal)
                return true;

            var possibleValues = GetPossibleValues(current).ToList();
            if (possibleValues.Count == 0)
                return false;

            foreach (var val in possibleValues)
            {
                _workingCopy.GetBlock(current.Block).SetSquareValue(current.Square, val);

                var square = current.Square.Next();
                var block = square.Equals(new Coordinates(0, 0)) ?
                    current.Block.Next() :
                    current.Block;
                var next = new Node(block, square);

                if (FindValues(next, counter + 1))
                    return true;
            }

            var originalValue = _referenceCopy.GetBlock(current.Block).GetSquareValue(current.Square);
            _workingCopy.GetBlock(current.Block).SetSquareValue(current.Square, originalValue);
            return false;
        }

        private IEnumerable<int> GetPossibleValues(Node node)
        {
            var referenceVal = _referenceCopy.GetBlock(node.Block).GetSquareValue(node.Square);
            if (referenceVal > 0)
                return new List<int> { referenceVal };

            var possible = new List<int>();
            for (var i = MinValue; i <= MaxValue; i++)
            {
                var inBlock = _workingCopy.GetBlock(node.Block).CheckValueExistsInBlock(i);
                var inRow = _workingCopy.CheckValueExistsInBoardRow(node.Block.Row, node.Square.Row, i);
                var inColumn = _workingCopy.CheckValueExistsInBoardColumn(node.Block.Column, node.Square.Column, i);
                if (inBlock || inRow || inColumn)
                    continue;

                possible.Add(i);
            }

            return possible;
        }
    }
}
