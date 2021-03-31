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
        public Client client;

        public String VM_from_reg
        {
            get
            {
                return client.From_reg;
            }
            set
            {
                client.From_reg = value;
            }

        }
        public String VM_IP
        {
            get
            {
                return client.IP;
            }
            set
            {
                client.IP = value;
            }

        }
        public int VM_Port
        {
            get
            {
                return client.Port;
            }
            set
            {
                client.Port = value;
            }

        }

        public LoadingFilesVM()
        {
            this.model = new LoadingFilesM();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
            this.client = new Client();
            client.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
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
        
        public void connectFG()
        {
            this.client.Connect();
        }
        

    }
}
