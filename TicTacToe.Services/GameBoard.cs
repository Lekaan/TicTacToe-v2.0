using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Services
{
    public class GameBoard
    {
        private static char[,] _currentGameBoard;

        public char[,] GetCurrentGameBoard {
            get { return _currentGameBoard; }
            set { }
        }

        public void CreateNewGameBoard()
        {
            _currentGameBoard = new char[3, 3]
                  {
                      {' ', ' ', ' '},
                      {' ', ' ', ' '},
                      {' ', ' ', ' '}
                  };
        }

        public char GetGameBoardField(string input)
        {
            int output = Int32.Parse(input);
            switch (output)
            {
                case 1:
                    return _currentGameBoard[0, 0];
                case 2:
                    return _currentGameBoard[0, 1];
                case 3:
                    return _currentGameBoard[0, 2];
                case 4:
                    return _currentGameBoard[1, 0];
                case 5:
                    return _currentGameBoard[1, 1];
                case 6:
                    return _currentGameBoard[1, 2];
                case 7:
                    return _currentGameBoard[2, 0];
                case 8:
                    return _currentGameBoard[2, 1];
                case 9:
                    return _currentGameBoard[2, 2];
            }
            throw new IndexOutOfRangeException("Please type a number between 1-9");
        }

        public void SetGameBoardField(string input)
        {
            GameManager gm = new GameManager();
            int output = Int32.Parse(input);
            char playerIcon = gm.GetPlayerIcon();

            switch (output)
            {
                case 1:
                     _currentGameBoard[0, 0] = playerIcon;
                    break;
                case 2:
                     _currentGameBoard[0, 1] = playerIcon;
                    break;
                case 3:
                     _currentGameBoard[0, 2] = playerIcon;
                    break;
                case 4:
                     _currentGameBoard[1, 0] = playerIcon;
                    break;
                case 5:
                     _currentGameBoard[1, 1] = playerIcon;
                    break;
                case 6:
                     _currentGameBoard[1, 2] = playerIcon;
                    break;
                case 7:
                     _currentGameBoard[2, 0] = playerIcon;
                    break;
                case 8:
                     _currentGameBoard[2, 1] = playerIcon;
                    break;
                case 9:
                     _currentGameBoard[2, 2] = playerIcon;
                    break;
            }
        }
        public void SetGameBoardBlankField(string input)
        {
            GameManager gm = new GameManager();
            int output = Int32.Parse(input);

            switch (output)
            {
                case 1:
                    _currentGameBoard[0, 0] = ' ';
                    break;
                case 2:
                    _currentGameBoard[0, 1] = ' ';
                    break;
                case 3:
                    _currentGameBoard[0, 2] = ' ';
                    break;
                case 4:
                    _currentGameBoard[1, 0] = ' ';
                    break;
                case 5:
                    _currentGameBoard[1, 1] = ' ';
                    break;
                case 6:
                    _currentGameBoard[1, 2] = ' ';
                    break;
                case 7:
                    _currentGameBoard[2, 0] = ' ';
                    break;
                case 8:
                    _currentGameBoard[2, 1] = ' ';
                    break;
                case 9:
                    _currentGameBoard[2, 2] = ' ';
                    break;
            }
        }

        public string PrintCurrentBoard()
        {
            string board =
                "            #       #                        #       #       \n" +
                "        " + GetGameBoardField("1") + "   #   " + GetGameBoardField("2") + "   #  " + GetGameBoardField("3") + "                 1   #   2   #   3   \n" +
                "            #       #                        #       #       \n" +
                "     #######################          #######################\n" +
                "            #       #                        #       #       \n" +
                "        " + GetGameBoardField("4") + "   #   " + GetGameBoardField("5") + "   #  " + GetGameBoardField("6") + "                 4   #   5   #   6   \n" +
                "            #       #                        #       #       \n" +
                "     #######################          #######################\n" +
                "            #       #                        #       #       \n" +
                "        " + GetGameBoardField("7") + "   #   " + GetGameBoardField("8") + "   #  " + GetGameBoardField("9") + "                 7   #   8   #   9   \n" +
                "            #       #                        #       #       \n";

            return board;
        }

        public int CountPlayerIcons()
        {
            GameManager gm = new GameManager();
            int playerIconCount=0;
            char playerIcon = gm.GetPlayerIcon();
            
            foreach (char c in _currentGameBoard)
            {
                if (c.Equals(playerIcon))
                    playerIconCount++;
            }
            return playerIconCount;
        }

        
    }
}
