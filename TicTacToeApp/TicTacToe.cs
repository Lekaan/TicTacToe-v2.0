using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Services;

namespace TicTacToeApp
{

    class TicTacToe
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            GameBoard gb = new GameBoard();
            GameManager.GameInProgress = true;
            GameManager.CurrentPlayer = true;

            gb.CreateNewGameBoard();

            while (GameManager.GameInProgress)
            {
                Console.Clear();
                Console.WriteLine(gm.PrintGameWelcomeMessage());
                Console.WriteLine(gb.PrintCurrentBoard());
                GameManager.IsValid = false;

                while (!GameManager.IsValid)
                {
                    gm.PrintCurrentPlayer();
                    gm.ValidateInput(Console.ReadLine());
                }
                GameWinnerService gs = new GameWinnerService();
                char winner = gs.Validate(gb.GetCurrentGameBoard);
                if (!winner.Equals(' '))
                    GameManager.GameInProgress = false;
                gm.TogglePlayer();
                
            }
            GameWinnerService gws = new GameWinnerService();
            char gamewinner = gws.Validate(gb.GetCurrentGameBoard);
            Console.Clear();
            Console.WriteLine(gm.PrintGameWelcomeMessage());
            Console.WriteLine(gb.PrintCurrentBoard());
            Console.WriteLine("===================================================================================\n");
            Console.WriteLine("   " + gamewinner + " WINS THE GAME!!!\n");
            Console.WriteLine("===================================================================================\n");
        }
    }
}
