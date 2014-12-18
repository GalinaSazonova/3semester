using System;
using System.Linq;
using System.IO;

namespace RobotsAndJumps
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "robotmatrix.txt";
            RobotMoves robM = new RobotMoves(fileName);
            bool w = robM.allRobotsDestoyed();
            Console.WriteLine(w);
        }
    }
}
