using System;
using System.Collections.Generic;
using System.ComponentModel;
using OxyPlot;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FlightSimulator2.model
{

    public class FeaturesGraphM : INotifyPropertyChanged
    {

        public string[] featuresArr = { "aileron", "elevator", "rudder", "flaps", "slats", "speedbrake", "throttle", "throttle", "engine-pump", "engine-pump", // flight features according to XML file
                    "electric-pump", "electric-pump", "external-power", "APU-generator", "latitude-deg", "longitude-deg", "altitude-ft", "roll-deg", "pitch-deg",
                    "heading-deg", "side-slip-deg", "airspeed-kt", "glideslope", "vertical-speed-fps", "airspeed-indicator_indicated-speed-kt", "altimeter_indicated-altitude-ft",
                    "altimeter_pressure-alt-ft", "attitude-indicator_indicated-pitch-deg", "attitude-indicator_indicated-roll-deg", "attitude-indicator_internal-pitch-deg",
                    "attitude-indicator_internal-roll-deg", "encoder_indicated-altitude-ft", "encoder_pressure-alt-ft", "gps_indicated-altitude-ft", "gps_indicated-ground-speed-kt",
                    "gps_indicated-vertical-speed", "indicated-heading-deg", "magnetic-compass_indicated-heading-deg", "slip-skid-ball_indicated-slip-skid",
                    "turn-indicator_indicated-turn-rate", "vertical-speed-indicator_indicated-speed-fpm", "engine_rpm"
        };


        public event PropertyChangedEventHandler PropertyChanged;
        private List<DataPoint> M_points;
        public List<DataPoint> M_Points
        {
            get { return M_points; }
            set
            {
                M_points = value;
                NotifyPropertyChanged(nameof(M_Points));
            }
        }

        public void NotifyPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public FeaturesGraphM()
        {
            this.M_points = new List<DataPoint>();
            this.M_points.Add(new DataPoint(3, 4));
            this.M_points.Add(new DataPoint(2, 4));
            this.M_points.Add(new DataPoint(3, 5));
            this.M_points.Add(new DataPoint(8, 4));
            this.M_points.Add(new DataPoint(3, 1));
            this.M_points.Add(new DataPoint(6, 4));
            this.M_points.Add(new DataPoint(3, 7));
            this.M_points.Add(new DataPoint(7, 4));
            this.M_points.Add(new DataPoint(9, 4));

        }
    }
}
