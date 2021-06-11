using AlgoProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgoProject.ViewModel
{
    class SortViewModel: INotifyPropertyChanged
    {
        SortModel sortModel;

        TypeSort selectedTypeSort;
        

        public SortViewModel()
        {
            sortModel = new SortModel();
        }

        public TypeSort SelectedTypeSort
        {
            get { return selectedTypeSort; }
            set
            {
                selectedTypeSort = value;
                OnPropertyChanged(nameof(SelectedTypeSort));
            }
        }

        public IEnumerable<TypeSort> AllTypeSort =>  Enum.GetValues(typeof(TypeSort)).Cast<TypeSort>();



        public void SortArray(TypeSort selectedTypeSort)
        {
            var m = Enum.GetValues(typeof(TypeSort)).Cast<TypeSort>();

            switch (selectedTypeSort)
            {
                case TypeSort.BubbleSort:
                    
                    break;
                case TypeSort.QuickSort:
                    break;
                case TypeSort.MergeSort:
                    break;
            }
        }

        private void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        public int[] GenerateArray(int volume)
        {
            int[] array = new int[volume];

            Random rnd = new Random();

            for (int row = 0; row < volume; row++)
            {
                array[row] = rnd.Next(0, 1000);
            }

            return array;
        }

        public int[] BubbleSort(int volume, int[] arr)
        {
            for (int i = 0; i < volume - 1; i++)
            {
                for (int j = 0; j < volume - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
            }
            return arr;
        }

        public void MergeSort(int volume, int[] arr)
        {

        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;


                }
                else
                {
                    return right;
                }
            }
        }

        public void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    QuickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(arr, pivot + 1, right);
                }
            }
        }


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
    }


    enum TypeSort
    {
        BubbleSort,
        QuickSort,
        MergeSort
    }

}
