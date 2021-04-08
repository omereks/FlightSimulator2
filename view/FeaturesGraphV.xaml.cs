using System;
using FlightSimulator2.viewModel;
using FlightSimulator2.model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OxyPlot;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightSimulator2.view
{
    /// <summary>
    /// Interaction logic for FeaturesGraphV.xaml
    /// </summary>
    public partial class FeaturesGraphV : UserControl
    {
        private FeaturesGraphVM _viewModel;
        public FeaturesGraphVM _ViewModel
        {
            get { return _ViewModel; }
        }
        public FeaturesGraphV()
        {
            InitializeComponent();
            _viewModel = new FeaturesGraphVM(new FeaturesGraphM());
            DataContext = _viewModel;
        }

        private void featuresListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // todo
        }
    }
}
