using System;
using System.IO;

namespace Local
{
    /// <summary>
    /// Class for analysing local network.
    /// </summary>
    public class LocalNetwork
    {
        private Random random;
        private bool[,] adjacencyMatrix;
        private PS[] PSList;
        private OS[] OSList;
        private int numberOfInfectedPS = 0;

        public LocalNetwork(string fileName)
        {
            random = new Random();
            NetworkFromFile(fileName);
        }

        private class PS
        {
            public PS(bool infected, OS OSType)
            {
                this.Infected = infected;
                this.OSType = OSType;
            }
            public bool Infected { get; set; }
            public OS OSType { get; set; }
        }

        private class OS
        {
            public OS(string name, int propability)
            {
                this.OSName = name;
                this.Probability = propability;
            }
            public string OSName { get; set; }
            public int Probability { get; set; }
        }

        private void NetworkFromFile(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            if (file == null)
            {
                throw new FileNotFoundException();
            }
            int numberOfPS = Convert.ToInt32(file.ReadLine());

            //Fill adjacency matrix.
            adjacencyMatrix = new bool[numberOfPS, numberOfPS];
            for (int i = 0; i < numberOfPS; i++)
            {
                string[] temp = file.ReadLine().Split(' ');
                for (int j = 0; j < numberOfPS; j++)
                {
                    adjacencyMatrix[i, j] = Convert.ToBoolean(Convert.ToInt32(temp[j]));
                }
            }

            //Fill list of OS.
            int numberOfOS = Convert.ToInt32(file.ReadLine());
            OSList = new OS[numberOfOS];
            for (int i = 0; i < numberOfOS; i++)
            {
                string[] temp = file.ReadLine().Split(' ');
                OSList[i] = new OS(temp[0], Convert.ToInt32(temp[1]));
            }

            //Fill list of PS.
            PSList = new PS[numberOfPS];
            for (int i = 0; i <numberOfPS; i++)
            {
                PSList[i] = new PS(false, OSByName(file.ReadLine()));
            }

            //Count alredy infected compters.
            string[] tempor = file.ReadLine().Split(' ');
            if (tempor != null)
            {
                numberOfInfectedPS = tempor.Length;
                for (int i = 0; i < numberOfInfectedPS; i++)
                {
                    PSList[Convert.ToInt32(tempor[i]) - 1].Infected = true;
                }
            }
            file.Close();
        }

        private OS OSByName(string name)
        {
            for (int i = 0; i < OSList.Length; i++)
            {
                if (name == OSList[i].OSName)
                    return OSList[i];
            }
            return null;
        }

        private void Move()
        {

        }
    }
}
