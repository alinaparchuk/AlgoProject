using System;

namespace AlgoProject.ViewModel
{
    public class GeneratingArray
    {
        /// <summary>Filling the array with random numbers.</summary>
        /// <param name="volume">Number of array elements.</param>
        /// <returns>int[volume] array.</returns>
        public int[] FillArray(int volume)
        {
            int[] array = new int[volume];
            Random rnd = new Random();

            for (int row = 0; row < volume; row++)
            {
                array[row] = rnd.Next(0, 9999);
            }

            return array;
        }
    }
}
