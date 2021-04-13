using System;
using System.Collections.Generic;
using System.ComponentModel;
using OxyPlot;
using System.Linq;
using System.Text;
using System.Threading;
using FlightSimulator2.view;

namespace FlightSimulator2.model
{



    public class FeaturesGraphM : INotifyPropertyChanged
    {
        private static int indexOfFeature;
        public static int IndexOfFeature
        {
            get { return indexOfFeature; }
            set
            {
                indexOfFeature = value;
                //NotifyPropertyChanged(nameof(IndexOfFeature));
            }
        }

        private static int indexOfCorrelatedFeature;
        public static int IndexOfCorrelatedFeature
        {
            get { return indexOfCorrelatedFeature; }
            set
            {
                indexOfCorrelatedFeature = value;
                //NotifyPropertyChanged(nameof(IndexOfFeature));
            }
        }


        private FeaturesGraphV view;
        public FeaturesGraphV View
        {
            get { return view; }
            set
            {
                view = value;
                NotifyPropertyChanged(nameof(View));
            }
        }


        public void updateFeaturesList()
        {
            bool isConnected = true;
            long currentLine = 0;
            new Thread(delegate ()
            {

            while (isConnected)
            {
                Thread.Sleep(100);
                if (Client.client_instance.currentFlightState() == null) { continue; }
                string[] flightsInsturment;
                flightsInsturment = Client.client_instance.currentFlightState().Split(',');


                    if (Client.client_instance.getCurrentLine() != -99)
                    {
                        currentLine = Client.client_instance.getCurrentLine();
                        
                    }
                    if (M_Points.Count != 0 && M_Points.Last().X > currentLine)
                    {
                        M_Points.Clear();
                        M_CorrelatedPoints.Clear();
                    }
                    DataPoint feature = new DataPoint(currentLine, Convert.ToDouble(flightsInsturment[indexOfFeature]));
                    DataPoint correlated = new DataPoint(currentLine, Convert.ToDouble(flightsInsturment[indexOfCorrelatedFeature]));
                    
                    M_Points.Add(feature);
                    M_CorrelatedPoints.Add(correlated);
                }
            }).Start();
        } 

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


        public void FeatureSelected(int selectedIndex)
        {
            M_Points.Clear();
            M_CorrelatedPoints.Clear();

            indexOfFeature = selectedIndex;
            string feature = listOfFeaturesNames[selectedIndex];
            int index = 0;
            string correlatedF = getCorreltadFeature(feature);
            for (int i = 0; i < listOfFeaturesNames.Count; i++)
            {
                if (correlatedF == listOfFeaturesNames[i]) index = i;
            }
            indexOfCorrelatedFeature = index;
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
            this.M_correlatedPoints = new List<DataPoint>();

            listOfFeaturesNames = new List<string> { "aileron", "elevator", "rudder", "flaps", "slats", "speedbrake", "throttle", "throttle", "engine-pump", "engine-pump", // flight features according to XML file
                    "electric-pump", "electric-pump", "external-power", "APU-generator", "latitude-deg", "longitude-deg", "altitude-ft", "roll-deg", "pitch-deg",
                    "heading-deg", "side-slip-deg", "airspeed-kt", "glideslope", "vertical-speed-fps", "airspeed-indicator_indicated-speed-kt", "altimeter_indicated-altitude-ft",
                    "altimeter_pressure-alt-ft", "attitude-indicator_indicated-pitch-deg", "attitude-indicator_indicated-roll-deg", "attitude-indicator_internal-pitch-deg",
                    "attitude-indicator_internal-roll-deg", "encoder_indicated-altitude-ft", "encoder_pressure-alt-ft", "gps_indicated-altitude-ft", "gps_indicated-ground-speed-kt",
                    "gps_indicated-vertical-speed", "indicated-heading-deg", "magnetic-compass_indicated-heading-deg", "slip-skid-ball_indicated-slip-skid",
                    "turn-indicator_indicated-turn-rate", "vertical-speed-indicator_indicated-speed-fpm", "engine_rpm"
            };
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
            updateFeaturesList();
        }
    }
}