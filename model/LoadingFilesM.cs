using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace FlightSimulator2.model
{
    class LoadingFilesM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private String from_playback;
        public String From_playback
        {
            get
            {

                return from_playback;
            }
            set
            {
                from_playback = value;
                NotifyPropertyChanged("From_playback");
            }
        }

        public void CopyXML(String src, String dst)
        {
            try
            {
                File.Copy(src, dst, true);
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }
        }

        public void NotifyPropertyChanged(String propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public void changeNameModel(String s)
        {
            from_playback = s;
        }


        
    }
}
