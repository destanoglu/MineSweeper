using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MineSweeper.UnitTest
{
    [TestClass]
    public class When_constructing_the_field_area
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void it_should_throw_exception_with_incompatible_field_input()
        {
            var field = new MineField(5, 4, new List<string> {"*...", "...."});
        }

        [TestMethod]
        public void it_should_place_mines_in_correct_position()
        {
            var field = new MineField(3, 4, new List<string> { "*...", "*.*.", "...." });

            Assert.AreEqual('*', field.GetElement(0, 0));
            Assert.AreEqual('*', field.GetElement(1, 0));
            Assert.AreEqual('*', field.GetElement(1, 2));
        }

        [TestMethod]
        public void it_should_place_all_mines()
        {
            var field = new MineField(3, 4, new List<string> { "*...", "*.*.", "...." });

            var mineCount = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mineCount += field.GetElement(i, j) == '*' ? 1 : 0;
                }
            }

            Assert.AreEqual(3, mineCount);
        }
    }
}
