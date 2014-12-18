using System;
using System.Linq;
using System.IO;

namespace RobotsAndJumps
{
    /// <summary>
    /// Class for reading from file.
    /// </summary>
    public class RobotMatrixFromFile
    {
        private bool[,] adjacencyMatrix;
        private int[] robotPlaces;
        private int numberOfVertices;

        public RobotMatrixFromFile(string fileName)
        {
            GraphAndRobotsFromFile(fileName);
        }

        private void GraphAndRobotsFromFile(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            if (file == null)
            {
                throw new FileNotFoundException();
            }
            numberOfVertices = Convert.ToInt32(file.ReadLine());
            adjacencyMatrix = new bool[numberOfVertices, numberOfVertices];
            for (int i = 0; i < numberOfVertices; i++)
            {
                string[] temp = file.ReadLine().Split(' ');
                for (int j = 0; j < numberOfVertices; j++)
                {
                    adjacencyMatrix[i, j] = Convert.ToBoolean(Convert.ToInt32(temp[j]));
                }
            }

            int numberOfRobots = Convert.ToInt32(file.ReadLine());
            robotPlaces = new int[numberOfRobots];
            string[] tempor = file.ReadLine().Split(' ');
            for (int i = 0; i < numberOfRobots; i++)
            {
                robotPlaces[i] = Convert.ToInt32(tempor[i]);
            }
            file.Close();
        }

        /// <summary>
        /// Returns true if there is a connection between vertices.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public bool isConnected(int a, int b)
        {
            return adjacencyMatrix[a, b];
        }

        /// <summary>
        /// Returns true if there is robot in vertix.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool robotPlace(int a)
        {
            return robotPlaces.Contains(a);
        }

        /// <summary>
        /// Returns number of vertices.
        /// </summary>
        /// <returns></returns>
        public int numberOfVert()
        {
            return numberOfVertices;
        }
    }
}
