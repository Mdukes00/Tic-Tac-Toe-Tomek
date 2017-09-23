using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace TicTacToeTomek
{
    public class Logic
    {
        const int MATRIX_ROWS = 4;
        const int MATRIX_COLUMNS = 4;

        public string[,] GetBoard()
        {
            string[,] matrix = new string[MATRIX_ROWS, MATRIX_COLUMNS];
            matrix = SetDots(matrix);
            matrix = setT(matrix);
            return matrix;
        }

        public string[,] SetDots(string[,] matrix)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    matrix.SetValue(".", i, j);

            }
            return matrix;
        }
        public bool switchCurrentPlayer(bool currentPlayer)
        {
            if (currentPlayer == true)
            {
                return false;
            }
            else
                return true;
        }

        public string[,] setT(string[,] matrix)
        {
            Random rnd = new Random();
            int row = rnd.Next(0, MATRIX_ROWS - 1);
            int column = rnd.Next(0, MATRIX_COLUMNS - 1);
            matrix.SetValue("T", row, column);

            return matrix;
        }


        public int checkForWin(string[,] board)
        {
            List<int> listOfScores = convertToScore(board);

            List<int> winningConditionsList = WinningConditions(listOfScores);

            for (int i = 0; i < 10; i++)
            {
                if (winningConditionsList[i] == 4 || winningConditionsList[i] == 103)
                {
                    return 1;
                }
                if (winningConditionsList[i] == 20 || winningConditionsList[i] == 115)
                {
                    return 2;
                }

            }
            if (winningConditionsList.Last() == 143)
            {
                return 3;
            }
            if (winningConditionsList.Last() == 0)
            {
                return 4;
            }

            return 0;

        }

        private List<int> WinningConditions(List<int> listOfScores)
        {
            List<int> winningConditionsList = new List<int>();
            //row 1 to 4 win
            winningConditionsList.Add(listOfScores[0] + listOfScores[1] + listOfScores[2] + listOfScores[3]);
            winningConditionsList.Add(listOfScores[4] + listOfScores[5] + listOfScores[6] + listOfScores[7]);
            winningConditionsList.Add(listOfScores[8] + listOfScores[9] + listOfScores[10] + listOfScores[11]);
            winningConditionsList.Add(listOfScores[12] + listOfScores[13] + listOfScores[14] + listOfScores[15]);
            //column 1 to 4 win
            winningConditionsList.Add(listOfScores[0] + listOfScores[4] + listOfScores[8] + listOfScores[12]);
            winningConditionsList.Add(listOfScores[1] + listOfScores[5] + listOfScores[9] + listOfScores[13]);
            winningConditionsList.Add(listOfScores[2] + listOfScores[6] + listOfScores[10] + listOfScores[14]);
            winningConditionsList.Add(listOfScores[3] + listOfScores[7] + listOfScores[11] + listOfScores[15]);
            //diagional wins
            winningConditionsList.Add(listOfScores[0] + listOfScores[5] + listOfScores[10] + listOfScores[15]);
            winningConditionsList.Add(listOfScores[12] + listOfScores[9] + listOfScores[6] + listOfScores[3]);
            //board is full or empty
            winningConditionsList.Add(listOfScores.Sum(item => item));

            return winningConditionsList;
        }

        public string readFromFile(string path)
        {
            return System.IO.File.ReadAllText(@"" + path);
        }

        public string[] stringToCharArray(string fileToString)
        {
            return fileToString.Split(null, (fileToString.Length / 4) * 10);
        }

        public void readFromTestFile(string path)
        {
            string stringFromFile = readFromFile(path);
            string[] stringToChar = stringToCharArray(stringFromFile);
            int numberOfTestCases = int.Parse(stringToChar.GetValue(0).ToString());
            int testCaseIndex = 0;

            for (int i = 0; i < numberOfTestCases; i++)
            {
                List<string> rowList;
                string[,] board;
                createListOfRows(stringToChar, testCaseIndex, out rowList, out board);
                fillBoardWithMarks(rowList, board);
                int winner = checkForWin(board);
                testCaseIndex = testCaseIndex + 5;
            }
        }

        private static void fillBoardWithMarks(List<string> rowList, string[,] board)
        {
            for (int row = 0; row < 4; row++)
            {
                int startOfRow = 0;
                for (int col = 0; col < 4; col++)
                {
                    board.SetValue(rowList[row].ToCharArray().GetValue(startOfRow).ToString(), row, col);
                    startOfRow++;
                }
            }
        }

        private static void createListOfRows(string[] stringToCharArray, int testCaseIndex, out List<string> rowList, out string[,] board)
        {
            rowList = new List<string>();
            board = new string[MATRIX_ROWS, MATRIX_COLUMNS];
            rowList.Add(stringToCharArray.GetValue(testCaseIndex + 1).ToString());
            rowList.Add(stringToCharArray.GetValue(testCaseIndex + 2).ToString());
            rowList.Add(stringToCharArray.GetValue(testCaseIndex + 3).ToString());
            rowList.Add(stringToCharArray.GetValue(testCaseIndex + 4).ToString());
        }

        public List<int> convertToScore(string[,] board)
        {
            List<int> convertToScoreList = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board.GetValue(i, j).ToString() == "X")
                    {
                        convertToScoreList.Add(1);
                    }
                    if (board.GetValue(i, j).ToString() == "O")
                    {
                        convertToScoreList.Add(5);
                    }
                    if (board.GetValue(i, j).ToString() == "T")
                    {
                        convertToScoreList.Add(100);
                    }
                    if (board.GetValue(i, j).ToString() == ".")
                    {
                        convertToScoreList.Add(0);
                    }
                }
            }
            return convertToScoreList;


        }
    }

}
