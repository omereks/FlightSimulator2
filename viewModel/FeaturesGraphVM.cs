﻿using FlightSimulator2.model;
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

        private string VM_correlatdeF;
        public string VM_CorrelatedF
        {
            get { return VM_correlatdeF; }
            set
            {
                VM_correlatdeF = value;
                NotifyPropertyChanged(nameof(VM_CorrelatedF));
            }
        }

        private string nameOfFeatureSelected;
        public string NameOfFeatureSelected
        {
            get { return nameOfFeatureSelected; }
            set { nameOfFeatureSelected = value;
                NotifyPropertyChanged(nameof(NameOfFeatureSelected));
                VM_CorrelatedF = model.getCorreltadFeature(value);
            }
        }


        private FeaturesGraphM model;
        public FeaturesGraphM Model
        {
            get { return model; }
        }

        public List<string> VM_FeaturesList
        {
            get { return model.ListOfFeaturesNames; }
            set
            {
                model.ListOfFeaturesNames = value;
                NotifyPropertyChanged(nameof(VM_FeaturesList));
            }
        }

        
        /*public double FeatureRange
        {
            get { return Model.M_FeatureRange; }
            set
            {
                Model.M_FeatureRange = value;
                NotifyPropertyChanged(nameof(FeatureRange));
            }
        }*/

        public List<DataPoint> VM_CorrelatedPoints
        {
            get { return model.M_CorrelatedPoints; }
            set
            {
                model.M_CorrelatedPoints = value;
                NotifyPropertyChanged(nameof(VM_CorrelatedPoints));
            }
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


        public void featureSelected(int selectedIndex)
        {
            
            this.model.FeatureSelected(selectedIndex);
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