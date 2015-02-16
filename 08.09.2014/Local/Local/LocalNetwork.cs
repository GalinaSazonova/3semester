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
        private PС[] PСList;
        private OS[] OSList;
        private int numberOfInfectedPС = 0;


        public LocalNetwork(string fileName)
        {
            random = new Random();
            NetworkFromFile(fileName);
        }

        private class PС
        {
            public PС(bool infected, OS OSType)
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
            int numberOfPС = Convert.ToInt32(file.ReadLine());

            //Fill adjacency matrix.
            adjacencyMatrix = new bool[numberOfPС, numberOfPС];
            for (int i = 0; i < numberOfPС; i++)
            {
                string[] temp = file.ReadLine().Split(' ');
                for (int j = 0; j < numberOfPС; j++)
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
            PСList = new PС[numberOfPС];
            for (int i = 0; i <numberOfPС; i++)
            {
                PСList[i] = new PС(false, OSByName(file.ReadLine()));
            }

            //Count alredy infected compters.
            string[] tempor = file.ReadLine().Split(' ');
            if (tempor[0] != "0")
            {
                numberOfInfectedPС = tempor.Length;
                for (int i = 0; i < numberOfInfectedPС; i++)
                {
                    PСList[Convert.ToInt32(tempor[i]) - 1].Infected = true;
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

        /// <summary>
        /// Makes 1 move to infect.
        /// </summary>
        public void Move()
        {
            bool[] justInfected = new bool[PСList.Length];
            for (int i = 0; i < justInfected.Length; i++)
            {
                justInfected[i] = false;
            }
            if (numberOfInfectedPС == 0)
            {
                for (int i = 0; i < PСList.Length; i++)
                {
                    if (!PСList[i].Infected && OSAllowToinfect(PСList[i]))
                    {
                        PСList[i].Infected = true;
                        numberOfInfectedPС++;
                    }
                }
                return;
            }
            for (int i = 0; i < PСList.Length; i++)
            {
                if (PСList[i].Infected && !justInfected[i])
                {
                    for (int j = 0; j < PСList.Length; j++)
                    {
                        if (!PСList[j].Infected && adjacencyMatrix[i, j] && OSAllowToinfect(PСList[j]))
                        {
                            PСList[j].Infected = true;
                            justInfected[j] = true;
                            numberOfInfectedPС++;
                        }
                    }
                }
            }
        }

        private bool OSAllowToinfect(PС pсToCheck)
        {
            return random.Next(99) <= pсToCheck.OSType.Probability;
        }

        /// <summary>
        /// Infect computers until they are all ill.
        /// </summary>
        /// <returns>list of infected ps</returns>
        public string InfectorOfGudjets()
        {
            string str = "";
            int counterOfMoves = 0;
            while (numberOfInfectedPС != PСList.Length)
            {
                counterOfMoves++;
                str += counterOfMoves + ". ";
                for (int i = 0; i < PСList.Length; i++)
                {
                    if (PСList[i].Infected)
                    {
                        str += (i + 1) + " ";
                    }
                }
                str += "\n";
                Move();
            }
            str += counterOfMoves + 1 + ". All PС are infected.";
            return str;
        }
    }
}
