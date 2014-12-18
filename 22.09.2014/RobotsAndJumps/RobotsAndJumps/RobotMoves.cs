using System.Collections.Generic;

namespace RobotsAndJumps
{
    public class RobotMoves
    {
        private RobotMatrixFromFile matrix;
        private int numberOfVert;

        public RobotMoves(string fileName)
        {
            matrix = new RobotMatrixFromFile(fileName);
            numberOfVert = matrix.numberOfVert();
        }

        /// <summary>
        /// Returns true, is all robots can be destroyed.
        /// </summary>
        /// <returns></returns>
        public bool allRobotsDestoyed()
        {
            bool[] robotIsDestroyed = new bool[numberOfVert];
            for (int i = 0; i < numberOfVert; i++)
            {
                robotIsDestroyed[i] = false;
            }
            for (int i = 0; i < numberOfVert; i++)
            {
                if (matrix.robotPlace(i) && !robotIsDestroyed[i])
                {
                    if (!thisRobotIsDesrtoyed(robotIsDestroyed, i))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        
        private bool thisRobotIsDesrtoyed(bool[] robotIsDestroyed, int robotPlace)
        {
            bool[] isChecked = new bool[numberOfVert];
            for (int i = 0; i < numberOfVert; i++)
            {
                isChecked[i] = false;
            }
            isChecked[robotPlace] = true;
            //int robotToCheck = robotPlace;
            List<int> robotToCheck = new List<int>();
            robotToCheck.Add(robotPlace);
            while (robotToCheck.Count != 0)
            {
                int robotOnChecking = robotToCheck[0];
                robotToCheck.Remove(robotOnChecking);
                if (matrix.robotPlace(robotOnChecking) && robotOnChecking != robotPlace)
                {
                    robotIsDestroyed[robotOnChecking] = true;
                    robotIsDestroyed[robotPlace] = true;
                    return true;
                }
                for (int i = 0; i < numberOfVert; i++)
                {
                    if (matrix.isConnected(robotOnChecking, i) && robotOnChecking != i)
                    {
                        for (int j = 0; j < numberOfVert; j++)
                        {
                            if (matrix.isConnected(i, j) && (!isChecked[j]) && (i != j))
                            {
                                isChecked[j] = true;
                                robotToCheck.Add(j);
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}
