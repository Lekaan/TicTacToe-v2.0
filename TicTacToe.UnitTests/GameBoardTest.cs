using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TicTacToe.Services;

namespace TicTacToe.UnitTests
{
    [TestFixture]
    class GameBoardTest
    {
        private char[,] _gameBoard;

        [SetUp]
        public void SetupUnitTests()
        {
            _gameBoard = new char[3, 3]
                  {
                      {' ', ' ', ' '},
                      {' ', ' ', ' '},
                      {' ', ' ', ' '}
                  };

            GameManager.CurrentPlayer = true;
        }

        [Test]
        public void CanCreateNewGameBoard()
        {
            GameBoard gb = new GameBoard();
            gb.CreateNewGameBoard();

            Assert.AreEqual(_gameBoard, gb.GetCurrentGameBoard);
        }
        [Test]
        public void CanGetStartingPlayer()
        {
            Assert.IsTrue(GameManager.CurrentPlayer);
        }

        [Test]
        public void CanGetPlayer1Icon()
        {
            GameManager gm = new GameManager();
            Assert.AreEqual('X', gm.GetPlayerIcon());
        }
        [Test]
        public void CanGetPlayer2Icon()
        {
            GameManager.CurrentPlayer = false;
            GameManager gm = new GameManager();
            Assert.AreEqual('O', gm.GetPlayerIcon());
        }

        [Test]
        public void CanGetGameBoardField()
        {
            GameBoard gb = new GameBoard();
            gb.CreateNewGameBoard();
            Assert.AreEqual(' ', gb.GetGameBoardField("1"));
        }

        [Test]
        public void CanSetGameBoardField()
        {
            GameBoard gb = new GameBoard();
            gb.CreateNewGameBoard();
            GameManager.CurrentPlayer = true;
            gb.SetGameBoardField("1");

            Assert.AreEqual('X', gb.GetGameBoardField("1"));
        }

        [Test]
        public void CanPrintCurrentGame()
        {
            GameBoard gb = new GameBoard();
            gb.CreateNewGameBoard();
            string expectedBoard =
                "            #       #                        #       #       \n" +
                "            #       #                    1   #   2   #   3   \n" +
                "            #       #                        #       #       \n" +
                "     #######################          #######################\n" +
                "            #       #                        #       #       \n" +
                "            #       #                    4   #   5   #   6   \n" +
                "            #       #                        #       #       \n" +
                "     #######################          #######################\n" +
                "            #       #                        #       #       \n" +
                "            #       #                    7   #   8   #   9   \n" +
                "            #       #                        #       #       \n";

            Assert.AreEqual(expectedBoard, gb.PrintCurrentBoard());
        }

        [Test]
        public void CanPrintPopulatedGameBoard()
        {
            GameBoard gb = new GameBoard();
            gb.CreateNewGameBoard();
            GameManager.CurrentPlayer = true;
            gb.SetGameBoardField("1");

            string expectedBoard =
                "            #       #                        #       #       \n" +
                "        X   #       #                    1   #   2   #   3   \n" +
                "            #       #                        #       #       \n" +
                "     #######################          #######################\n" +
                "            #       #                        #       #       \n" +
                "            #       #                    4   #   5   #   6   \n" +
                "            #       #                        #       #       \n" +
                "     #######################          #######################\n" +
                "            #       #                        #       #       \n" +
                "            #       #                    7   #   8   #   9   \n" +
                "            #       #                        #       #       \n";

            Assert.AreEqual(expectedBoard, gb.PrintCurrentBoard());
        }

        [Test]
        public void CanCountPlayerIcons()
        {
            GameBoard gb = new GameBoard();
            gb.CreateNewGameBoard();
            gb.SetGameBoardField("1");
            gb.SetGameBoardField("2");
            Assert.AreEqual(2, gb.CountPlayerIcons());
        }

        [Test]
        public void CanCheckWinner()
        {
            GameBoard gb = new GameBoard();
            GameWinnerService gs = new GameWinnerService();
            gb.CreateNewGameBoard();
            gb.SetGameBoardField("1");
            gb.SetGameBoardField("2");
            gb.SetGameBoardField("3");

            Assert.AreEqual('X', gs.Validate(gb.GetCurrentGameBoard));
        }

        [Test]
        public void CanPrintWelcomeMessage()
        {
            GameManager gm = new GameManager();

            string expectedString = "\n======================================[TicTacToe]==================================\n" +
                         "                           Made by Jonas, Peter and Morten                         \n" +
                         "===================================================================================\n" +
                         "\n" +
                         "TicTacToe is a 2 player game where players takes turn and place their Player Icon\n" +
                         "with to goal to get 3 in a row either horizontally, vertically or diagonally.\n" +
                         "Each player can max have 3 Player Icons and can after placing down 3 Player Icons,\n" +
                         "move their own Player Icons until a winner have been found.\n" +
                         "\n";

            Assert.AreEqual(expectedString, gm.PrintGameWelcomeMessage());
        }

        [Test]
        public void CanTogglePlayer()
        {
            Assert.IsTrue(GameManager.CurrentPlayer);
            GameManager gm = new GameManager();
            gm.TogglePlayer();
            Assert.IsFalse(GameManager.CurrentPlayer);
        }
    }
}
