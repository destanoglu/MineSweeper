using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MineSweeper.UnitTest
{
    [TestClass]
    public class When_generating_solution
    {
        [TestMethod]
        public void it_should_contain_elements()
        {
            var field = new MineField(3, 4, new List<string> {"*...", "*.*.", "...."});
            var sweeper = new MineSweeper(field);

            Assert.AreEqual(true, sweeper.GenerateSolution().Any());
        }

        [TestMethod]
        public void it_should_count_correct_mine_count_for_a_neighbourhood()
        {
            var field = new MineField(3, 4, new List<string> { "*...", "*.*.", "...." });
            var sweeper = new MineSweeper(field);
            
            Assert.AreEqual("1", sweeper.GetMineCount(0, 2));
            Assert.AreEqual(MineField.MINE.ToString(), sweeper.GetMineCount(0, 0));
            Assert.AreEqual("3", sweeper.GetMineCount(1, 1));
        }

        [TestMethod]
        public void it_should_generate_the_correct_the_solution()
        {
            var field = new MineField(4, 4, new List<string> { "*...", "*.*.", "....", "...*" });
            var sweeper = new MineSweeper(field);

            var solution = sweeper.GenerateSolution();

            Assert.AreEqual(4, solution.Count);
            Assert.AreEqual("*311", solution[0]);
            Assert.AreEqual("*3*1", solution[1]);
            Assert.AreEqual("1222", solution[2]);
            Assert.AreEqual("001*", solution[3]);
        }
    }
}