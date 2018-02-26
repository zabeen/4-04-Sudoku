using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.GameLogic
{
    public class Game
    {
        private IGameBoard _board;

        public Game(IGameBoard board)
        {
            _board = board;
        }

        public void PlayGame()
        {
            for (var i = 0; i < _board.Board.Length; i++)
            {
                for (int j = 0; j < _board.Board.Length; j++)
                {
                    CalculateSquare(i, j);
                    _board.WriteBoard();
                }
            }
        }

        private void CalculateSquare(int rowIndex, int colIndex)
        {

        }
    }
}
