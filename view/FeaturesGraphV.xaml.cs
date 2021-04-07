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

namespace FlightSimulator2.view
{
    /// <summary>
    /// Interaction logic for FeaturesGraph.xaml
    /// </summary>
    public partial class FeaturesGraph : UserControl
    {

        private string[] featuresArr = { "aileron", "elevator", "rudder", "flaps", "slats", "speedbrake", "throttle", "throttle", "engine-pump", "engine-pump", // flight features according to XML file
            "electric-pump", "electric-pump", "external-power", "APU-generator", "latitude-deg", "longitude-deg", "altitude-ft", "roll-deg", "pitch-deg",
            "heading-deg", "side-slip-deg", "airspeed-kt", "glideslope", "vertical-speed-fps", "airspeed-indicator_indicated-speed-kt", "altimeter_indicated-altitude-ft",
            "altimeter_pressure-alt-ft", "attitude-indicator_indicated-pitch-deg", "attitude-indicator_indicated-roll-deg", "attitude-indicator_internal-pitch-deg",
            "attitude-indicator_internal-roll-deg", "encoder_indicated-altitude-ft", "encoder_pressure-alt-ft", "gps_indicated-altitude-ft", "gps_indicated-ground-speed-kt",
            "gps_indicated-vertical-speed", "indicated-heading-deg", "magnetic-compass_indicated-heading-deg", "slip-skid-ball_indicated-slip-skid",
            "turn-indicator_indicated-turn-rate", "vertical-speed-indicator_indicated-speed-fpm", "engine_rpm"};


        private void bindListBox()
        {
            featuresListBox.ItemsSource = featuresArr;
        }

        private void featuresListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public FeaturesGraph()
        {
            InitializeComponent();
            bindListBox();
        }
    }
}
