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
        private string timeAlgorithm;

        public string TimeAlgorithm
        {
            get { return timeAlgorithm; }
            set
            {
                timeAlgorithm = value;
                OnPropertyChanged(nameof(TimeAlgorithm));
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
