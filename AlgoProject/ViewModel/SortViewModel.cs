using AlgoProject.Model;
using AlgoProject.ViewModel.SortingTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AlgoProject.ViewModel
{
    public class SortViewModel : INotifyPropertyChanged
    {        
        private ICommand sortCom;
        private ObservableCollection<SortModel> sortData;
        private SortModel sortModel;
        private SortingHandler sortingHandler;

        public IEnumerable<int> AllNumberElements => new[] { 10000, 25000, 50000, 100000 };

        public IEnumerable<TypeSort> AllTypeSort => Enum.GetValues(typeof(TypeSort)).Cast<TypeSort>();

        public string ElapsedTime
        {
            get
            { 
                return sortModel.ElapsedTime; 
            }
            set
            {
                sortModel.ElapsedTime = value;
                OnPropertyChanged(nameof(ElapsedTime));
            }
        }

        public int SelectedNumberElements
        {
            get
            {
                return sortModel.SelectedNumberElements;
            }
            set
            {
                sortModel.SelectedNumberElements = value;
                OnPropertyChanged(nameof(SelectedNumberElements));
            }
        }

        public TypeSort SelectedTypeSort
        {
            get 
            { 
                return sortModel.SelectedTypeSort; 
            }
            set
            {
                sortModel.SelectedTypeSort = value;
                OnPropertyChanged(nameof(SelectedTypeSort));
            }
        }

        public ICommand SortCom => sortCom ?? (sortCom = new CommandBase(this.UpdateData));

        public ObservableCollection<SortModel> SortData
        {
            get 
            { 
                return sortData; 
            }
            set
            {
                sortData = value;
                OnPropertyChanged(nameof(SortData));
            }
        }

        /// <summary>ViewModel constructor.</summary>
        public SortViewModel()
        {
            sortModel = new SortModel();
            sortData = new ObservableCollection<SortModel>();
            sortingHandler = new SortingHandler();
        }

        /// <summary>Adds sorting data into <see cref="SortData"/>.</summary>
        /// <param name="value">Optional parameter.</param>
        public void UpdateData(object value = null)
        {
            SortData.Add(sortingHandler.Handle(this.SelectedTypeSort, SelectedNumberElements));
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
    }
}
