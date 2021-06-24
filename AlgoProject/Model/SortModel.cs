using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AlgoProject.Model
{
    public class SortModel : INotifyPropertyChanged
    {
        private string elapsedTime;
        private int selectedNumberElements;
        private TypeSort selectedTypeSort;

        public string ElapsedTime
        {
            get { return elapsedTime; }
            set
            {
                elapsedTime = value;
                OnPropertyChanged(nameof(ElapsedTime));
            }
        }

        public int SelectedNumberElements
        {
            get
            {
                return selectedNumberElements == 0 ? 10000 : selectedNumberElements;
            }
            set
            {
                selectedNumberElements = value;
                OnPropertyChanged(nameof(SelectedNumberElements));
            }
        }

        public TypeSort SelectedTypeSort
        {
            get 
            {
                return selectedTypeSort; 
            }
            set
            {
                selectedTypeSort = value;
                OnPropertyChanged(nameof(SelectedTypeSort));
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
}
