namespace AlgoProject.ViewModel.SortingTypes
{
    class MergeSort : ISort
    {
        /// <summary>Sorting an array using the algorithm "Merge sort".</summary>
        /// <param name="array">Array with random digits.</param>
        public void Sort(int[] array)
        {
            Sorting(array, 0, array.Length - 1);
        }

        /// <summary>Method for sort and fragmentation arrays.</summary>
        /// <param name="array">Array with random digits.</param>
        /// <param name="lowIndex">Array start index.</param>
        /// <param name="highIndex">Array end index.</param>
        private void Sorting(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                int middleIndex = (lowIndex + highIndex) / 2;
                Sorting(array, lowIndex, middleIndex);
                Sorting(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }
        }

        /// <summary>Method for merging arrays.</summary> 
        /// <param name="array">Array with random digits.</param>
        /// <param name="lowIndex">Array start index.</param>
        /// <param name="middleIndex">Midpoint index.</param>
        /// <param name="highIndex">Array end index.</param>
        private void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            int left = lowIndex;
            int right = middleIndex + 1;
            int[] tempArray = new int[highIndex - lowIndex + 1];
            int index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (int i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (int i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (int i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

    }
}
