using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoProject.ViewModel.SortingTypes
{
    class QuickSort : ISort
    {
        public void Sort(int[] array)
        {
            Sorting(array, 0, array.Length - 1);
        }

        private void Sorting(int[] arr, int first, int last)
        {
            int p = arr[(last - first) / 2 + first]; // ищем средний элемент
            int temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (arr[i] < p && i <= last)
                    ++i;
                while (arr[j] > p && j >= first) 
                    --j;

                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    ++i; 
                    --j;
                }
            }
            if (j > first) Sorting(arr, first, j);
            if (i < last) Sorting(arr, i, last);
        }
               
    }
}
