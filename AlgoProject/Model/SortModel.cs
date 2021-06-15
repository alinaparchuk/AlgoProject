using AlgoProject.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgoProject.Model
{
    class SortModel : INotifyPropertyChanged
    {
        private string elapsedTime;
        private TypeSort selectedTypeSort;
        private int selectedNumberElements;

        public string ElapsedTime
        {
            get { return elapsedTime; }
            set
            {
                elapsedTime = value;
                OnPropertyChanged(nameof(ElapsedTime));
            }
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

        public int SelectedNumberElements
        {
            get { return selectedNumberElements; }
            set
            {
                selectedNumberElements = value;
                OnPropertyChanged(nameof(SelectedNumberElements));
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
