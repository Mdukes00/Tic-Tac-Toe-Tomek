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
        Logic logic = new Logic();

        [TestMethod]
        public void SwitchPlayer_switchesPlayer_true()
        {
            //setup
            bool currentPlayer = true;

            //act
            currentPlayer = logic.switchCurrentPlayer(currentPlayer);
            currentPlayer = logic.switchCurrentPlayer(currentPlayer);
            currentPlayer = logic.switchCurrentPlayer(currentPlayer);

            //assert
            Assert.AreEqual(false, currentPlayer);
        }

        [TestMethod]
        public void GetBoard_setsARandomTinTheMatrix_True()
        {
            string[,] emptyMatrix = new string[MATRIX_ROWS, MATRIX_COLUMNS];
            int numberOfT = 0;

            //act
            emptyMatrix = logic.SetDots(emptyMatrix);
            emptyMatrix = logic.setT(emptyMatrix);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (emptyMatrix.GetValue(i, j).ToString() == "T")
                    {
                        numberOfT++;
                    }
                }
            }

            //assert
            Assert.AreEqual(1, numberOfT);
        }

        [TestMethod]
        public void setDots_setMatrixToStart_True()
        {
            //setup
            string[,] emptyMatrix = new string[MATRIX_ROWS, MATRIX_COLUMNS];
            int numberOfDots = 0;

            //act
            emptyMatrix = logic.SetDots(emptyMatrix);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (emptyMatrix.GetValue(i, j).ToString() == ".")
                    {
                        numberOfDots++;
                    }
                }
            }

            //assert
            Assert.AreEqual(16, numberOfDots);
        }

        [TestMethod]
        public void readFromFile()
        {

            //setup
            string fileToString = "";

            //act
            fileToString = logic.readFromFile("C:/Users/Public/TestFolder/test.txt");

            Assert.AreEqual("test", fileToString);






        }

    }


}




