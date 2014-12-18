using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotsAndJumps;
using System.IO;

namespace RobotTest
{
    [TestClass]
    public class RobotJTest
    {
        [TestInitialize]
        public void Initialize()
        {
            writer = new StreamWriter(fileName);
            writer.WriteLine("5");
            writer.WriteLine("0 1 0 1 0");
            writer.WriteLine("1 0 1 0 0");
            writer.WriteLine("0 1 0 1 0");
            writer.WriteLine("1 0 1 0 1");
            writer.WriteLine("0 0 0 1 0");
        }

        [TestMethod]
        public void MoveFalseTest()
        {
            writer.WriteLine("3");
            writer.WriteLine("1 2 4");
            writer.Close();
            robM = new RobotMoves(fileName);
            Assert.IsFalse(robM.allRobotsDestoyed());
        }

        [TestMethod]
        public void MoveTrueTest()
        {
            writer.WriteLine("2");
            writer.WriteLine("1 3");
            writer.Close();
            robM = new RobotMoves(fileName);
            Assert.IsTrue(robM.allRobotsDestoyed());
        }

        [TestCleanup]
        public void DeleteFile()
        {
            File.Delete(fileName);
        }

        private RobotMoves robM;
        private StreamWriter writer;
        private string fileName = "robotmatrix.txt";
    }
}
