using FlightSimulator2.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using OxyPlot.Annotations;
using OxyPlot;
using OxyPlot.Axes;
using FlightSimulator2.viewModel;

namespace FlightSimulator2.viewModel
{
    public class FeaturesGraphVM : INotifyPropertyChanged
    {
        private FeaturesGraphM model;
        public FeaturesGraphM Model
        {
            get { return model; }
        }

        public List<string> VM_FeaturesList
        {
            get { return model.M_FeaturesList; }
        }

        public List<DataPoint> VM_Points
        {
            get { return model.M_Points; }
            set
            {
                model.M_Points = value;
                NotifyPropertyChanged(nameof(VM_Points));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }

        }
        public void featureSelected(string selectedItem)
        {
            this.model.FeatureSelected(selectedItem);
        }

        public FeaturesGraphVM(FeaturesGraphM model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
    }
}
