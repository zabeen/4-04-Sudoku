using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.GameLogic
{
    public class Game
    {
        private IBoard _board;

        public Game(IBoard board)
        {
            _board = board;
        }

        public void PlayGame()
        {
            for (var i = 0; i < _board.CurrentGame.Length; i++)
            {
                for (int j = 0; j < _board.CurrentGame.Length; j++)
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
