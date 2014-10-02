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
            writer.Write("3" + '\n'
                        + "1 1 0" + '\n'
                        + "1 1 1" + '\n'
                        + "0 1 1" + '\n'
                        + "3" + '\n'
                        + "mac 20" + '\n'
                        + "win 80" + '\n'
                        + "lin 50" + '\n'
                        + "mac" + '\n'
                        + "win" + '\n'
                        + "lin" + '\n'
                        + "0");
            writer.Close();
            LocalNetwork network = new LocalNetwork(fileName);
            string str = network.InfectorOfGudjets();
            Console.WriteLine(str);
        }
    }
}
