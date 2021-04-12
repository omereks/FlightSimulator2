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

        private string correlatdeF;
        public string CorrelatedF
        {
            get { return correlatdeF; }
            set
            {
                correlatdeF = value;
                NotifyPropertyChanged(nameof(CorrelatedF));
            }
        }

        private List<string> listOfFeaturesNames;
        public List<string> ListOfFeaturesNames
        {
            get { return listOfFeaturesNames; }
            set
            {
                listOfFeaturesNames = value;
                NotifyPropertyChanged(nameof(ListOfFeaturesNames));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;



        private List<DataPoint> M_correlatedPoints;
        public List<DataPoint> M_CorrelatedPoints
        {
            get { return M_correlatedPoints; }
            set
            {
                M_correlatedPoints = value;
                NotifyPropertyChanged(nameof(M_CorrelatedPoints));
            }
        }


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

        private List<List<DataPoint>> M_featuresLists; // List of Lists of features

        public List<List<DataPoint>> M_FeaturesLists
        {
            get { return M_featuresLists; }
            set
            {
                M_featuresLists = value;
                NotifyPropertyChanged(nameof(M_FeaturesLists));
            }
        }


        public void FeatureSelected(int selectedIndex)
        {
            M_Points = M_FeaturesLists[selectedIndex]; // change features arr to list
            string feature = listOfFeaturesNames[selectedIndex];
            int index = 0;
            string correlatedF = getCorreltadFeature(feature);
            for (int i = 0; i < listOfFeaturesNames.Count; i++)
            {
                if (correlatedF == listOfFeaturesNames[i]) index = i;
            }

            M_CorrelatedPoints = M_FeaturesLists[index];
        }

        public void NotifyPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        // init according to xml file
        public void initFeaturesList()
        {
            this.M_Points = new List<DataPoint>();

            listOfFeaturesNames = new List<string> { "aileron", "elevator", "rudder", "flaps", "slats", "speedbrake", "throttle", "throttle", "engine-pump", "engine-pump", // flight features according to XML file
                    "electric-pump", "electric-pump", "external-power", "APU-generator", "latitude-deg", "longitude-deg", "altitude-ft", "roll-deg", "pitch-deg",
                    "heading-deg", "side-slip-deg", "airspeed-kt", "glideslope", "vertical-speed-fps", "airspeed-indicator_indicated-speed-kt", "altimeter_indicated-altitude-ft",
                    "altimeter_pressure-alt-ft", "attitude-indicator_indicated-pitch-deg", "attitude-indicator_indicated-roll-deg", "attitude-indicator_internal-pitch-deg",
                    "attitude-indicator_internal-roll-deg", "encoder_indicated-altitude-ft", "encoder_pressure-alt-ft", "gps_indicated-altitude-ft", "gps_indicated-ground-speed-kt",
                    "gps_indicated-vertical-speed", "indicated-heading-deg", "magnetic-compass_indicated-heading-deg", "slip-skid-ball_indicated-slip-skid",
                    "turn-indicator_indicated-turn-rate", "vertical-speed-indicator_indicated-speed-fpm", "engine_rpm"
            };
        }


        public void updateFeaturesList()
        {
            int counter = 0;
            bool isConnected = true;
            long currentLine = -97;
            new Thread(delegate ()
            {
                while (isConnected)
                {
                    if (Client.client_instance.currentFlightState() == null) { continue; }
                    string[] flightsInsturment;
                    flightsInsturment = Client.client_instance.currentFlightState().Split(',');
                    if (Client.client_instance.getCurrentLine() != -99) currentLine = Client.client_instance.getCurrentLine();
                    for (int i = 0; i < listOfFeaturesNames.Count; i++)
                    {
                        DataPoint p = new DataPoint(currentLine, Convert.ToDouble(flightsInsturment[i]));
                        // add every value to its list of values of every feature
                        M_FeaturesLists[i].Add(p);
                    }
                    NotifyPropertyChanged(nameof(M_FeaturesLists)); // todo maybe delete
                    counter++;
                }
            }).Start();
        }

        public void initFeaturesDict()
        {
            M_FeaturesLists = new List<List<DataPoint>>();
            for (int i = 0; i < listOfFeaturesNames.Count; i++)
            {
                // add every value to its list of values of every feature
                M_FeaturesLists.Add(new List<DataPoint>());
                //M_featuresDict[M_featuresList[i]] = new List<string>();
            }
        }


        // find correlated feature
        public string getCorreltadFeature(string feature)
        {
            if (feature == "aileron") return "slip-skid-ball_indicated-slip-skid";
            if (feature == "elevator") return "altimeter_indicated-altitude-ft";
            if (feature == "rudder") return "aileron";
            if (feature == "flaps") return "aileron";
            if (feature == "slats") return "aileron";
            if (feature == "speedbrake") return "aileron";
            if (feature == "throttle") return "engine_rpm";
            if (feature == "throttle1") return "aileron";
            if (feature == "engine-pump") return "aileron";
            if (feature == "engine-pump1") return "aileron";
            if (feature == "electric-pump") return "aileron";
            if (feature == "electric-pump1") return "aileron";
            if (feature == "external-power") return "aileron";
            if (feature == "APU-generator") return "aileron";
            if (feature == "latitude-deg") return "aileron";
            if (feature == "longitude-deg") return "aileron";
            if (feature == "altitude-ft") return "airspeed-indicator_indicated-speed-kt";
            if (feature == "roll-deg") return "attitude-indicator_internal-roll-deg";
            if (feature == "pitch-deg") return "attitude-indicator_internal-pitch-deg";
            if (feature == "heading-deg") return "indicated-heading-deg";
            if (feature == "side-slip-deg") return "airspeed-kt";
            if (feature == "airspeed-kt") return "airspeed-indicator_indicated-speed-kt";
            if (feature == "glideslope") return "vertical-speed-fps";
            if (feature == "vertical-speed-fps") return "gps_indicated-vertical-speed";
            if (feature == "airspeed-indicator_indicated-speed-kt") return "gps_indicated-ground-speed-kt";
            if (feature == "altimeter_indicated-altitude-ft") return "altimeter_pressure-alt-ft";
            if (feature == "altimeter_pressure-alt-ft") return "encoder_pressure-alt-ft";
            if (feature == "attitude-indicator_indicated-pitch-deg") return "attitude-indicator_internal-pitch-deg";
            if (feature == "attitude-indicator_indicated-roll-deg") return "attitude-indicator_internal-roll-deg";
            if (feature == "attitude-indicator_internal-pitch-deg") return "gps_indicated-vertical-speed";
            if (feature == "attitude-indicator_internal-roll-deg") return "turn-indicator_indicated-turn-rate";
            if (feature == "encoder_indicated-altitude-ft") return "encoder_pressure-alt-ft";
            if (feature == "encoder_pressure-alt-ft") return "gps_indicated-altitude-ft";
            if (feature == "gps_indicated-altitude-ft") return "gps_indicated-ground-speed-kt";
            if (feature == "gps_indicated-ground-speed-kt") return "slip-skid-ball_indicated-slip-skid";
            if (feature == "gps_indicated-vertical-speed") return "vertical-speed-indicator_indicated-speed-fpm";
            if (feature == "indicated-heading-deg") return "engine_rpm";
            if (feature == "magnetic-compass_indicated-heading-deg") return "turn-indicator_indicated-turn-rate";
            if (feature == "slip-skid-ball_indicated-slip-skid") return "turn-indicator_indicated-turn-rate";
            if (feature == "turn-indicator_indicated-turn-rate") return "vertical-speed-indicator_indicated-speed-fpm";
            if (feature == "vertical-speed-indicator_indicated-speed-fpm") return "engine_rpm";
            if (feature == "engine_rpm") return "aileron";
            return "aileron";
        }

        public FeaturesGraphM()
        {
            initFeaturesList();
            initFeaturesDict();
            updateFeaturesList();



            //M_points = M_featuresDict[15];

            /*this.M_points.Add(new DataPoint(3, 4));
            this.M_points.Add(new DataPoint(4, 3));
            this.M_points.Add(new DataPoint(5, 7));
            this.M_points.Add(new DataPoint(6, 2));
            this.M_points.Add(new DataPoint(7, 5));
            this.M_points.Add(new DataPoint(8, 7));
            this.M_points.Add(new DataPoint(9, 3));
            this.M_points.Add(new DataPoint(10, 8));
            this.M_points.Add(new DataPoint(11, 9));*/
        }
    }
}