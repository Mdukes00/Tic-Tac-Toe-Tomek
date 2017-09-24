using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TicTacToeTomek
{
    public class Logic : ILogic
    {
        private const int BOARD_ROWS = 4;
        private const int BOARD_COLUMNS = 4;

        private string currentPlayer = "X";
        private List<int> listOfScores = new List<int>();
        private List<int> winningConditionsList = new List<int>();


        public string[,] getBoard()
        {
            string[,] activeBoard = new string[BOARD_ROWS, BOARD_COLUMNS];
            return activeBoard;
        }

        public string[,] SetDots(string[,] activeBoard)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    activeBoard.SetValue(".", i, j);
            }
            return activeBoard;

        }
        public string switchCurrentPlayer()
        {
            if (currentPlayer == "X")
            {
                currentPlayer = "O";
                return currentPlayer;
            }
            else
            {
                currentPlayer = "X";
                return currentPlayer;
            }

        }

        public string[,] setT(string[,] activeBoard)
        {
            Random rnd = new Random();
            if (rnd.Next(0, 2) == 0)
            {
                Random rndT = new Random();
                int row = rndT.Next(0, BOARD_ROWS - 1);
                int column = rndT.Next(0, BOARD_COLUMNS - 1);
                activeBoard.SetValue("T", row, column);
                return activeBoard;

            }
            return activeBoard;


        }

        public void playGame()
        {
            bool isGameFinished = false;
            string[,] activeBoard = getBoard();
            activeBoard = SetDots(activeBoard);
            activeBoard = setT(activeBoard);
            while (!isGameFinished)
            {

                showBoard(activeBoard);
                activeBoard = setMark(activeBoard);
                switch (checkForWin(activeBoard))
                {
                    case 1:
                        isGameFinished = true;
                        Console.WriteLine("X won");
                        break;
                    case 2:
                        isGameFinished = true;
                        Console.WriteLine("O won");
                        break;
                    case 3:
                        isGameFinished = true;
                        Console.WriteLine("Draw");
                        break;
                    default:
                        switchCurrentPlayer();
                        Console.WriteLine("Player " + currentPlayer + "'s turn");
                        break;
                }
            }
        }

        private void showBoard(string[,] board)
        {
            string printBoard = "";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    printBoard = printBoard + board.GetValue(i, j).ToString();
                }
            }

            for (int i = 0; i < 16; i = i + 4)
            {
                Console.WriteLine(printBoard[i].ToString() + printBoard[i + 1].ToString() + printBoard[i + 2].ToString() + printBoard[i + 3].ToString());

            }

        }
        public string[,] setMark(string[,] activeBoard)
        {
            bool correctInput = false;
            int row = -1;
            int column = -1;
            while (!correctInput)
            {
                correctInput = checkIsEmpty(correctInput, out row, out column, activeBoard);
                if (!correctInput)
                {
                    Console.WriteLine("incorrect input. Please try again");
                    showBoard(activeBoard);
                }

            }
            activeBoard.SetValue(currentPlayer, row, column);
            return activeBoard;
        }

        public bool checkIsEmpty(bool correctInput, out int row, out int column, string[,] activeBoard)
        {
            Console.WriteLine("enter row number 0 to 3");
            row = int.Parse(Console.ReadLine().ToString());
            Console.WriteLine("enter column number 0 to 3");
            column = int.Parse(Console.ReadLine().ToString());

            if (row >= 0 && row <= 3)
            {
                if (column >= 0 && column <= 3)
                {
                    correctInput = isEmpty(row, column, activeBoard);
                }
            }

            return correctInput;
        }

        public bool isEmpty(int row, int column, string[,] activeBoard)
        {
            string value = activeBoard.GetValue(row, column).ToString();
            if (value == ".")
            {
                return true;
            }
            return false;

        }

        public int checkForWin(string[,] activeBoard)
        {
            List<int> listOfScores = convertToScore(activeBoard);

            List<int> winningConditionsList = WinningConditions(listOfScores);

            for (int i = 0; i < 10; i++)
            {
                if (winningConditionsList[i] == 4 || winningConditionsList[i] == 103)
                {
                    //X wins
                    return 1;
                }
                if (winningConditionsList[i] == 20 || winningConditionsList[i] == 115)
                {
                    //O wins
                    return 2;
                }

            }
            if (winningConditionsList.Last() == 143 || winningConditionsList.Last() == 48)
            {
                //No one wins
                return 3;
            }
            //Not finish
            return 4;

        }

        public List<int> WinningConditions(List<int> listOfScores)
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
            //board is full
            winningConditionsList.Add(listOfScores.Sum(item => item));

            return winningConditionsList;
        }

        public string readFromFile(string path)
        {
            return File.ReadAllText(@"" + path);
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
                List<string> rowList = createListOfRows(stringToChar, testCaseIndex);
                string[,] activeBoard = fillBoardWithMarks(rowList);
                List<string> listOfCases = new List<string>();
                switch (checkForWin(activeBoard))
                {
                    case 1:
                        listOfCases.Add("Case #" + (i + 1) + ": X won");
                        break;
                    case 2:
                        listOfCases.Add("Case #" + (i + 1) + ": O won");
                        break;
                    case 3:
                        listOfCases.Add("Case #" + (i + 1) + ": Draw");
                        break;
                    case 4:
                        listOfCases.Add("Case #" + (i + 1) + ": Game has not completed");
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
                testCaseIndex = testCaseIndex + 5;
                string fileName = "C:/Users/Public/TestFolder/testcases";
                using (FileStream fileStream = new FileStream(fileName, FileMode.Append))
                {
                    using (StreamWriter sw = new StreamWriter(fileStream, Encoding.ASCII))
                    {
                        foreach(string testcases in listOfCases)
                        {
                            sw.WriteLine(testcases);
                        }
                    }
                }




            }
        }

        public string[,] fillBoardWithMarks(List<string> rowList)
        {
            string[,] activeBoard = getBoard();
            for (int row = 0; row < 4; row++)
            {
                int startOfRow = 0;
                for (int col = 0; col < 4; col++)
                {
                    activeBoard.SetValue(rowList[row].ToCharArray().GetValue(startOfRow).ToString(), row, col);
                    startOfRow++;
                }
            }
            return activeBoard;
        }

        public List<string> createListOfRows(string[] stringToCharArray, int testCaseIndex)
        {
            List<string> rowList = new List<string>();
            rowList.Add(stringToCharArray.GetValue(testCaseIndex + 1).ToString());
            rowList.Add(stringToCharArray.GetValue(testCaseIndex + 2).ToString());
            rowList.Add(stringToCharArray.GetValue(testCaseIndex + 3).ToString());
            rowList.Add(stringToCharArray.GetValue(testCaseIndex + 4).ToString());
            return rowList;
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
