using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Services
{
    public interface IGameWinnerService
    {
        char Validate(char[,] gameBoard);
    }

    public class GameWinnerService : IGameWinnerService
    {
        private const char SymbolForNoWinner = ' ';

        public char Validate(char[,] gameBoard)
        {
            var currentWinningSymbol = CheckForThreeInARowInHorizontalRow(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;
            currentWinningSymbol = CheckForThreeInARowInVerticalColumn(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;
            currentWinningSymbol = CheckForThreeInARowIn2ndVerticalColumn(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;
            currentWinningSymbol = CheckForThreeInARowIn3rdVerticalColumn(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;
            currentWinningSymbol = CheckForThreeInARowIn2ndHorizontalRow(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;
            currentWinningSymbol = CheckForThreeInARowIn3rdHorizontalRow(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;
            currentWinningSymbol = CheckForThreeInARowDiagonallyDownLeft(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;
            currentWinningSymbol = CheckForThreeInARowDiagonally(gameBoard);
            return currentWinningSymbol;
        }

        private static char CheckForThreeInARowInVerticalColumn(char[,] gameBoard)
        {
            var rowOneChar = gameBoard[0, 0];
            var rowTwoChar = gameBoard[1, 0];
            var rowThreeChar = gameBoard[2, 0];
            if (rowOneChar == rowTwoChar &&
                rowTwoChar == rowThreeChar)
            {
                return rowOneChar;
            }
            return SymbolForNoWinner;
        }

        private static char CheckForThreeInARowIn2ndVerticalColumn(char[,] gameBoard)
        {
            var rowOneChar = gameBoard[0, 1];
            var rowTwoChar = gameBoard[1, 1];
            var rowThreeChar = gameBoard[2, 1];
            if (rowOneChar == rowTwoChar &&
                rowTwoChar == rowThreeChar)
            {
                return rowOneChar;
            }
            return SymbolForNoWinner;
        }

        private static char CheckForThreeInARowIn3rdVerticalColumn(char[,] gameBoard)
        {
            var rowOneChar = gameBoard[0, 2];
            var rowTwoChar = gameBoard[1, 2];
            var rowThreeChar = gameBoard[2, 2];
            if (rowOneChar == rowTwoChar &&
                rowTwoChar == rowThreeChar)
            {
                return rowOneChar;
            }
            return SymbolForNoWinner;
        }

        private static char CheckForThreeInARowInHorizontalRow(char[,] gameBoard)
        {
            var columnOneChar = gameBoard[0, 0];
            var columnTwoChar = gameBoard[0, 1];
            var columnThreeChar = gameBoard[0, 2];
            if (columnOneChar == columnTwoChar && 
                columnTwoChar == columnThreeChar)
            {
                return columnOneChar;
            }
            return SymbolForNoWinner;
        }

        private static char CheckForThreeInARowIn2ndHorizontalRow(char[,] gameBoard)
        {
            var columnOneChar = gameBoard[1, 0];
            var columnTwoChar = gameBoard[1, 1];
            var columnThreeChar = gameBoard[1, 2];
            if (columnOneChar == columnTwoChar &&
                columnTwoChar == columnThreeChar)
            {
                return columnOneChar;
            }
            return SymbolForNoWinner;
        }

        private static char CheckForThreeInARowIn3rdHorizontalRow(char[,] gameBoard)
        {
            var columnOneChar = gameBoard[2, 0];
            var columnTwoChar = gameBoard[2, 1];
            var columnThreeChar = gameBoard[2, 2];
            if (columnOneChar == columnTwoChar &&
                columnTwoChar == columnThreeChar)
            {
                return columnOneChar;
            }
            return SymbolForNoWinner;
        }

        private static char CheckForThreeInARowDiagonally(char[,] gameBoard)
        {
            var cellOneChar = gameBoard[0, 0];
            var cellTwoChar = gameBoard[1, 1];
            var cellThreeChar = gameBoard[2, 2];
            if (cellOneChar == cellTwoChar &&
                cellTwoChar == cellThreeChar)
            {
                return cellOneChar;
            }
            return SymbolForNoWinner;
        }
        private static char CheckForThreeInARowDiagonallyDownLeft(char[,] gameBoard)
        {
            var cellOneChar = gameBoard[2, 0];
            var cellTwoChar = gameBoard[1, 1];
            var cellThreeChar = gameBoard[0, 2];
            if (cellOneChar == cellTwoChar &&
                cellTwoChar == cellThreeChar)
            {
                return cellOneChar;
            }
            return SymbolForNoWinner;
        }
    }
}
