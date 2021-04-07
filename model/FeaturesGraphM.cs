using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FlightSimulator2.model
{

    class FeaturesGraphM : INotifyPropertyChanged
    {
        bool isConnect;
        private string[] featuresArr = { "aileron", "elevator", "rudder", "flaps", "slats", "speedbrake", "throttle", "throttle", "engine-pump", "engine-pump", // flight features according to XML file
            "electric-pump", "electric-pump", "external-power", "APU-generator", "latitude-deg", "longitude-deg", "altitude-ft", "roll-deg", "pitch-deg",
            "heading-deg", "side-slip-deg", "airspeed-kt", "glideslope", "vertical-speed-fps", "airspeed-indicator_indicated-speed-kt", "altimeter_indicated-altitude-ft",
            "altimeter_pressure-alt-ft", "attitude-indicator_indicated-pitch-deg", "attitude-indicator_indicated-roll-deg", "attitude-indicator_internal-pitch-deg",
            "attitude-indicator_internal-roll-deg", "encoder_indicated-altitude-ft", "encoder_pressure-alt-ft", "gps_indicated-altitude-ft", "gps_indicated-ground-speed-kt",
            "gps_indicated-vertical-speed", "indicated-heading-deg", "magnetic-compass_indicated-heading-deg", "slip-skid-ball_indicated-slip-skid",
            "turn-indicator_indicated-turn-rate", "vertical-speed-indicator_indicated-speed-fpm", "engine_rpm"};

        public event PropertyChangedEventHandler PropertyChanged;

        public void updateFeaturesValues()
        {
            new Thread(delegate ()
            {
                while (isConnect)
                {
                    if (Client.client_instance.currentFlightState() == null) continue;
                    for (int i = 0; i < featuresArr.Length; i++)
                    {
                      //  featuresArr[i] = csvFile[i];
                      // TODO 
                    }
                }
            }).Start();
        }
    }
}
