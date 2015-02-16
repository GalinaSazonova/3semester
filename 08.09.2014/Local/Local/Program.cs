using System;
using System.IO;

namespace Local
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "parameter.txt";
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
            LocalNetwork network = new LocalNetwork(fileName);
            string str = network.InfectorOfGudjets();
            Console.WriteLine(str);
        }
    }
}
