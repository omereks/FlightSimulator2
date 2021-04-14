using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FlightSimulator2.model;
using System.ComponentModel;
using OxyPlot.Annotations;
using OxyPlot;
using OxyPlot.Axes;
using FlightSimulator2.viewModel;

namespace FlightSimulator2.viewModel
{
    class RegresionLineVM
    {
        RegresionLineM rl;

        public event PropertyChangedEventHandler PropertyChanged;

        public RegresionLineVM(RegresionLineM new_reg_line)
        {
            this.rl = new_reg_line;
            this.rl.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e) {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public List<DataPoint> VM_Points
        {
            get
            {
                return this.rl.Points;
            }

            set
            {
                this.rl.Points = value;
                NotifyPropertyChanged("VM_Points");
            }
        }

        public List<DataPoint> VM_LineByPoints
        {
            get
            {
                return this.rl.LineByPoints;
            }
            
            set
            {
                this.rl.LineByPoints = value;
                NotifyPropertyChanged(nameof(VM_LineByPoints));
            }
        }

        public Line VM_Reg_line
        {
            get
            {
                return this.rl.Reg_line;
            }

            set
            {
                this.rl.Reg_line = value;
                NotifyPropertyChanged("VM_Reg_line");
            }
        }

       /* public void FindRegLine()
        {
            this.rl.Reg_line.linear_reg(this.X_feature_list, this.Y_feature_list, this.X_feature_list.Count());
        }*/
        public List<DataPoint> X_feature_list
        {
            get
            {
                return this.rl.X_feature_list;
            }

            set
            {
                this.rl.X_feature_list = value;
                NotifyPropertyChanged("VM_X_feature_list");
            }
        }

        public List<DataPoint> Y_feature_list
        {
            get
            {
                return this.rl.Y_feature_list;
            }

            set
            {
                this.rl.Y_feature_list = value;
                NotifyPropertyChanged("VM_Y_feature_list");
            }
        }
        public string X_feature
        {
            get
            {
                return this.rl.X_feature;
            }

            set
            {
                this.rl.X_feature = value;
                NotifyPropertyChanged("VM_X_feature");
            }
        }

        public string Y_feature
        {
            get
            {
                return this.rl.Y_feature;
            }

            set
            {
                this.rl.Y_feature = value;
                NotifyPropertyChanged("VM_Y_feature");
            }
        }


        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

    }
}
