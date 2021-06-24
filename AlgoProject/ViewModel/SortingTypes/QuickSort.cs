namespace AlgoProject.ViewModel.SortingTypes
{
    public class QuickSort : ISort
    {
        /// <summary>Sorting an array using the algorithm "Quick sort".</summary>
        /// <param name="array">Array with random digits.</param>
        public void Sort(int[] array)
        {
            Sorting(array, 0, array.Length - 1);
        }

        /// <summary>Method for sort array.</summary>
        /// <param name="array">Array with random digits.</param>
        /// <param name="first">Array start index.</param>
        /// <param name="last">Array end index.</param>
        private void Sorting(int[] array, int first, int last)
        {
            int p = array[(last - first) / 2 + first];
            int temp;
            int i = first, j = last;

            while (i <= j)
            {
                while (array[i] < p && i <= last)
                {
                    ++i;
                }

                while (array[j] > p && j >= first)
                {
                    --j;
                }

                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    ++i;
                    --j;
                }
            }

            if (j > first)
            {
                Sorting(array, first, j);
            }

            if (i < last)
            {
                Sorting(array, i, last);
            }
        }
    }
}
