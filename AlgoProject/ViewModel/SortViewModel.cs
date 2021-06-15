using AlgoProject.Model;
using AlgoProject.ViewModel.SortingTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AlgoProject.ViewModel
{
    class SortViewModel: INotifyPropertyChanged
    {        
        ISort sort;
        ICommand _sortCom; 
        SortModel sortModel;
        Action<int[]> sortAction;

        int[] DataArray { get; set; }

        public SortViewModel()
        {
            sortModel = new SortModel();
            sortData = new ObservableCollection<SortModel>();
        }

        public string ElapsedTime
        {
            get { return sortModel.ElapsedTime; }
            set
            {
                sortModel.ElapsedTime = value;
                OnPropertyChanged(nameof(ElapsedTime));
            }
        }

        public TypeSort SelectedTypeSort
        {
            get { return sortModel.SelectedTypeSort; }
            set
            {
                sortModel.SelectedTypeSort = value;
                OnPropertyChanged(nameof(SelectedTypeSort));
            }
        }

        public int SelectedNumberElements
        {
            get { return sortModel.SelectedNumberElements; }
            set
            {
                sortModel.SelectedNumberElements = value;
                OnPropertyChanged(nameof(SelectedNumberElements));
            }
        }

        private ObservableCollection<SortModel> sortData { get; set; }

        public ObservableCollection<SortModel> SortData
        {
            get { return sortData; }
            set
            {
                sortData = value;
                OnPropertyChanged(nameof(SortData));
            }
        }

        public IEnumerable<TypeSort> AllTypeSort =>  Enum.GetValues(typeof(TypeSort)).Cast<TypeSort>();

        public IEnumerable<int> AllNumberElements => new[] { 10000, 25000, 50000, 100000 };


        public ICommand SortCom => _sortCom ?? (_sortCom = new CommandBase(SortArray));

        public void SortArray(object value = null)
        {
            DataArray = GenerateArray(SelectedNumberElements);
            switch (SelectedTypeSort)
            {
                case TypeSort.BubbleSort:
                    sort = new BubbleSort();
                    sortAction = (DataArray) => sort.Sort(DataArray);
                    ElapsedTime = CalculateTime(sortAction);
                    SortData.Add(new SortModel() 
                    { 
                        SelectedNumberElements = this.SelectedNumberElements, 
                        SelectedTypeSort = this.SelectedTypeSort,
                        ElapsedTime = this.ElapsedTime });
                    break;

                case TypeSort.QuickSort:
                    sort = new QuickSort();
                    sortAction = (DataArray) => sort.Sort(DataArray);
                    ElapsedTime = CalculateTime(sortAction);
                    SortData.Add(new SortModel()
                    {
                        SelectedNumberElements = this.SelectedNumberElements,
                        SelectedTypeSort = this.SelectedTypeSort,
                        ElapsedTime = this.ElapsedTime
                    });
                    break;

                case TypeSort.MergeSort:
                    sort = new BubbleSort();
                    sortAction = (DataArray) => sort.Sort(DataArray);
                    ElapsedTime = CalculateTime(sortAction);
                    SortData.Add(new SortModel()
                    {
                        SelectedNumberElements = this.SelectedNumberElements,
                        SelectedTypeSort = this.SelectedTypeSort,
                        ElapsedTime = this.ElapsedTime
                    });
                    break;
            }
        }


        public string CalculateTime(Action<int[]> Sort)
        {
            var stopWatch = Stopwatch.StartNew();
            Sort(DataArray);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            return string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);             
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

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
    }
}
