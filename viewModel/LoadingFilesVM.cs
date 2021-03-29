using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator2.model;

namespace FlightSimulator2.viewModel
{
    class LoadingFilesVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public LoadingFilesM model;

        public LoadingFilesVM()
        {
            this.model = new LoadingFilesM();

            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public void NotifyPropertyChanged(String propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public void changeName(String s)
        {
            model.changeNameModel(s);
            NotifyPropertyChanged(VM_from_playback);
        }

        public String VM_from_playback
        {
            get
            {
                return model.From_playback;
            }
            set
            {
                VM_from_playback = value;
                NotifyPropertyChanged("from_playback");
            }
        }
        public String to_playback;


    }
}
