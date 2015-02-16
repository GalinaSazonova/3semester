using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Local;
using System.IO;

namespace LANTest
{
    [TestClass]
    public class LANTest
    {
        [TestInitialize]
        public void Initialize()
        {
            StreamWriter writer = new StreamWriter(fileName);
            writer.Write("5" + '\n'
                        + "0 1 0 0 0" + '\n'
                        + "1 0 1 0 0" + '\n'
                        + "0 1 0 1 0" + '\n'
                        + "0 0 1 0 1" + '\n'
                        + "0 0 0 1 0" + '\n'
                        + "3" + '\n'
                        + "mac 20" + '\n'
                        + "win 70" + '\n'
                        + "lin 50" + '\n'
                        + "mac" + '\n'
                        + "win" + '\n'
                        + "lin" + '\n'
                        + "lin" + '\n'
                        + "mac" + '\n'
                        + "1");
            writer.Close();
            network = new LocalNetwork(fileName);
        }

        [TestMethod]
        public void MoveTest()
        {
           string str = network.InfectorOfGudjets();
           Assert.IsTrue(str[3] == '1');
           Assert.IsTrue(str[str.Length - 1] == '.');
        }

        [TestCleanup]
        public void Clean()
        {
            File.Delete(fileName);
        }

        LocalNetwork network;
        string fileName = "parameter.txt";
 
    }
}
