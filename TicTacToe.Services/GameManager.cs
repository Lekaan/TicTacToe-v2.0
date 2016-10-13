using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Services
{
    public class GameManager
    {
        private static bool _currentPlayer;
        private static bool _gameInProgress;
        private static bool _isValid;
        public static bool CurrentPlayer { get { return _currentPlayer; } set { _currentPlayer = value; } }
        public static bool GameInProgress { get { return _gameInProgress; } set { _gameInProgress = value; } }
        public static bool IsValid { get { return _isValid; } set { _isValid = value; } }

        public char GetPlayerIcon()
        {
            if (_currentPlayer)
                return 'X';
            return 'O';
        }

        public string PrintGameWelcomeMessage()
        {
            string msg = "\n======================================[TicTacToe]==================================\n" +
                         "                           Made by Jonas, Peter and Morten                         \n" +
                         "===================================================================================\n" +
                         "\n" +
                         "TicTacToe is a 2 player game where players takes turn and place their Player Icon\n" +
                         "with to goal to get 3 in a row either horizontally, vertically or diagonally.\n" +
                         "Each player can max have 3 Player Icons and can after placing down 3 Player Icons,\n" +
                         "move their own Player Icons until a winner have been found.\n" +
                         "\n";
            return msg;
        }

        public void PrintCurrentPlayer()
        {
            GameBoard gb = new GameBoard();
            int count = gb.CountPlayerIcons();

            string playermsg;
            string player = "Player";

            if (count < 3)
                playermsg = "Please type a number between 1 - 9!";
            else
                playermsg = "Please type 2 numbers between 1 - 9. (Example: '1 3', to move Player Icon from field 1 to field 3)";

            if (CurrentPlayer)
                player += "1: ";
            else
                player += "2: ";

            Console.WriteLine(playermsg);
            Console.Write(player);

        }

        public void ValidateInput(string input)
        {
            GameBoard gb = new GameBoard();
            int playerIcons = gb.CountPlayerIcons();
            

            if (playerIcons < 3)
            {
                char field = gb.GetGameBoardField(input);
                if (field.Equals(' '))
                {
                    gb.SetGameBoardField(input);
                    IsValid = true;
                }
                else
                    Console.WriteLine("This field is already populated. Choose another field");
            }
            else
            {
                GameManager gm = new GameManager();
                char playerIcon = gm.GetPlayerIcon();

                string[] output = input.Split(' ');
                
                if (output.Length == 2)
                {
                    char moveFrom = gb.GetGameBoardField(output[0]);
                    char moveTo = gb.GetGameBoardField(output[1]);

                    if (moveFrom.Equals(playerIcon))
                    {
                        if (moveTo.Equals(' '))
                        {
                            gb.SetGameBoardBlankField(output[0]);
                            gb.SetGameBoardField(output[1]);
                            IsValid = true;
                        }
                        else
                        {
                            Console.WriteLine("You can only move to an unpopulated field");
                        }
                    }
                    else
                        Console.WriteLine("You can only move your own Player Icons");
                }


            }
        }

        public void TogglePlayer()
        {
            if (CurrentPlayer)
                CurrentPlayer = false;
            else
                CurrentPlayer = true;
        }
    }
}
