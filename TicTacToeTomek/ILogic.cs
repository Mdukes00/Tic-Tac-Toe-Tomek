using System.Collections.Generic;

namespace TicTacToeTomek
{
    public interface ILogic
    {
        int checkForWin(string[,] activeBoard);
        bool checkIsEmpty(bool correctInput, out int row, out int column, string[,] activeBoard);
        List<int> convertToScore(string[,] board);
        List<string> createListOfRows(string[] stringToCharArray, int testCaseIndex);
        string[,] fillBoardWithMarks(List<string> rowList);
        string[,] getBoard();
        bool isEmpty(int row, int column, string[,] activeBoard);
        void playGame();
        string readFromFile(string path);
        void readFromTestFile(string path);
        string[,] SetDots(string[,] activeBoard);
        string[,] setMark(string[,] activeBoard);
        string[,] setT(string[,] activeBoard);
        string[] stringToCharArray(string fileToString);
        string switchCurrentPlayer();
        List<int> WinningConditions(List<int> listOfScores);
    }
}