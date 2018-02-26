using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
            public Node Next => NextNode();

            public Node(Coordinates block, Coordinates square)
            {
                Block = block;
                Square = square;
            }

            public Node NextNode()
            {
                var square = Square.Next();
                var block = square.Equals(new Coordinates(0, 0)) ? Block.Next() : Block;

                return new Node(block, square);
            }
        }

        private readonly IBoard _referenceCopy;
        private readonly IBoard _workingCopy;
        private const int SquaresTotal = 81;
        private const int MinValue = 1;
        private const int MaxValue = 9;

        public Solution(IBoard board)
        {
            _workingCopy = board;
            _referenceCopy = board.CopyBoard();
        }

        public void SolveBoard()
        {
            var startingBlock = new Coordinates(0, 0);
            var startingSquare = new Coordinates(0, 0);

            FindValues(new Node(startingBlock, startingSquare));
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

                if (FindValues(current.Next, counter + 1))
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
