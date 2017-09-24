using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeTomek;
using System.Collections.Generic;

namespace TicTacToeTomekTests
{
    [TestClass]
    public class LogicTests
    {
        const int MATRIX_ROWS = 4;
        const int MATRIX_COLUMNS = 4;
        ILogic logic = new Logic();


        [TestMethod]
        public void checkForWin_wincase1_xwins()
        {
            //setup
            int expected = 1;
            string[,] board = logic.getBoard();
            string xWins = "1\nTXOX\nXOXO\nXOXO\nX...";
            string[] stringToChar = logic.stringToCharArray(xWins);
            int testCaseIndex = 0;
            List<string> rowList = logic.createListOfRows(stringToChar, testCaseIndex);
            string[,] activeBoard = logic.fillBoardWithMarks(rowList);

            //act
            int actual = logic.checkForWin(activeBoard);

            //assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void checkForWin_wincase2_Owins()
        {
            //setup
            int expected = 2;
            string[,] board = logic.getBoard();
            string xWins = "1\nTOOO\nXOXX\nOXOX\nX..X";
            string[] stringToChar = logic.stringToCharArray(xWins);
            int testCaseIndex = 0;
            List<string> rowList = logic.createListOfRows(stringToChar, testCaseIndex);
            string[,] activeBoard = logic.fillBoardWithMarks(rowList);

            //act
            int actual = logic.checkForWin(activeBoard);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void checkForWin_wincase3_draw()
        {
            //setup
            int expected = 3;
            string[,] board = logic.getBoard();
            string xWins = "1\nTXOX\nOXOX\nOXOX\nXOXO";
            string[] stringToChar = logic.stringToCharArray(xWins);
            int testCaseIndex = 0;
            List<string> rowList = logic.createListOfRows(stringToChar, testCaseIndex);
            string[,] activeBoard = logic.fillBoardWithMarks(rowList);

            //act
            int actual = logic.checkForWin(activeBoard);

            //assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void checkForWin_wincase4_stillplaying()
        {
            //setup
            int expected = 4;
            string[,] board = logic.getBoard();
            string xWins = "1\nT...\n....\n....\nXOXO";
            string[] stringToChar = logic.stringToCharArray(xWins);
            int testCaseIndex = 0;
            List<string> rowList = logic.createListOfRows(stringToChar, testCaseIndex);
            string[,] activeBoard = logic.fillBoardWithMarks(rowList);

            //act
            int actual = logic.checkForWin(activeBoard);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void switchCurrentPlayer_switchesPlayer_O()
        {
            //setup
            string currentPlayer = "X";

            //act
            currentPlayer = logic.switchCurrentPlayer();
            currentPlayer = logic.switchCurrentPlayer();
            currentPlayer = logic.switchCurrentPlayer();

            //assert
            Assert.AreEqual("O", currentPlayer);
        }

        [TestMethod]
        public void readFromFile_readstestfromfile_correct()
        {

            //setup
            string fileToString = "";

            //act
            fileToString = logic.readFromFile("C:/Users/Public/TestFolder/test.txt");

            //assert
            Assert.AreEqual("test", fileToString);

        }

    }


}




