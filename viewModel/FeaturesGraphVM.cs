using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using OxyPlot.Annotations;
using OxyPlot;
using OxyPlot.Axes;

namespace FlightSimulator2.viewModel
{
    class FeaturesGraphVM : INotifyPropertyChanged
    {
        private PlotModel plotModel;
        public PlotModel PlotModel
        {
            get { return plotModel; }
            set 
            {
                plotModel = value;
                OnPropertyChanged("PlotModel");
            }
        }

        public List<DataPoint> featurePoints;
        public string[] featuresArr = { "aileron", "elevator", "rudder", "flaps", "slats", "speedbrake", "throttle", "throttle", "engine-pump", "engine-pump", // flight features according to XML file
            "electric-pump", "electric-pump", "external-power", "APU-generator", "latitude-deg", "longitude-deg", "altitude-ft", "roll-deg", "pitch-deg",
            "heading-deg", "side-slip-deg", "airspeed-kt", "glideslope", "vertical-speed-fps", "airspeed-indicator_indicated-speed-kt", "altimeter_indicated-altitude-ft",
            "altimeter_pressure-alt-ft", "attitude-indicator_indicated-pitch-deg", "attitude-indicator_indicated-roll-deg", "attitude-indicator_internal-pitch-deg",
            "attitude-indicator_internal-roll-deg", "encoder_indicated-altitude-ft", "encoder_pressure-alt-ft", "gps_indicated-altitude-ft", "gps_indicated-ground-speed-kt",
            "gps_indicated-vertical-speed", "indicated-heading-deg", "magnetic-compass_indicated-heading-deg", "slip-skid-ball_indicated-slip-skid",
            "turn-indicator_indicated-turn-rate", "vertical-speed-indicator_indicated-speed-fpm", "engine_rpm"};

        public event PropertyChangedEventHandler PropertyChanged;
        /// [NotifyPropertyChangedInvocator]


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        public FeaturesGraphVM()
        {
            PlotModel = new PlotModel();
        }

        private void SetUpModel()
        {
            PlotModel.LegendTitle = "Graph";
            PlotModel.LegendOrientation = LegendOrientation.Horizontal;
            PlotModel.LegendPlacement = LegendPlacement.Outside;
            PlotModel.LegendPosition = LegendPosition.TopRight;
            PlotModel.LegendBackground = OxyColor.FromAColor(200, OxyColors.White);
            PlotModel.LegendBorder = OxyColors.Black;

            PlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Minimum = 0, MinorGridlineStyle = LineStyle.Dot, Maximum = 100 });            
            PlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = 0, MinorGridlineStyle = LineStyle.Dot, Maximum = 100 });
        }

    }
}
