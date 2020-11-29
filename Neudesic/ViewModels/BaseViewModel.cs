using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Neudesic.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool isConnectionAvailable;
        public bool IsConnectionAvailable
        {
            get { return isConnectionAvailable; }
            set
            {
                if (isConnectionAvailable != value)
                {
                    isConnectionAvailable = value;
                    OnPropertyChanged("IsConnectionAvailable");
                }
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
