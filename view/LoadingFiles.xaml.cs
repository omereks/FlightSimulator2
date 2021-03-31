using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using FlightSimulator2.viewModel;

namespace FlightSimulator2.view
{
    /// <summary>
    /// Interaction logic for LoadingFiles.xaml
    /// </summary>
    public partial class LoadingFiles : UserControl
    {
        
        
        LoadingFilesVM loadingFilesViewModel;


        public LoadingFiles()
        {
            InitializeComponent();
            loadingFilesViewModel = new LoadingFilesVM();
            DataContext = loadingFilesViewModel;
        }

        private void from_playback_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void IP_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CopyXML_Click(object sender, RoutedEventArgs e)
        {
            loadingFilesViewModel.copyXML();
        }
        private void ConnectFG_Click(object sender, RoutedEventArgs e)
        {
            loadingFilesViewModel.connectFG();
        }
    }
}
