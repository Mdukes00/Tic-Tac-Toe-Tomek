using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeTomek;

namespace TicTacToeTomekTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SwitchPlayer_switchesPlayer_true()
        {
            //setup
            Logic logic = new Logic();
            bool currentPlayer = true;

            //act
            currentPlayer = logic.switchCurrentPlayer(currentPlayer);
            currentPlayer = logic.switchCurrentPlayer(currentPlayer);
            currentPlayer = logic.switchCurrentPlayer(currentPlayer);

            //assert
            Assert.AreEqual(false, currentPlayer);
        }

    }
}
