using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;

namespace FlightSimulator2.model
{
    class JoystickM : INotifyPropertyChanged
    {
        private bool disconnect;
        private int elevator_idx, aileron_idx, throttle_idx, rudder_idx;
        private double elevator, aileron, throttle, rudder;
        public event PropertyChangedEventHandler PropertyChanged;
        /*PlayerControlBarM control_bar;
        Client client;*/

        public JoystickM()
        {
            this.disconnect = false;
            this.aileron_idx = 0;
            this.elevator_idx = 1;
            this.throttle_idx = 7;
            this.rudder_idx = 2;
        }
        public double Elevator
        {
            get
            {
                return elevator;
            }

            set
            {
                elevator = value;
                NotifyPropertyChanged("Elevator");
            }

        }

        public double Aileron
        {
            get
            {
                return aileron;
            }

            set
            {
                aileron = value;
                NotifyPropertyChanged("Aileron");
            }

        }

        public double Throttle
        {
            get
            {
                return throttle;
            }

            set
            {
                throttle = value;
                NotifyPropertyChanged("Throttle");
            }

        }

        public double Rudder
        {
            get
            {
                return rudder;
            }

            set
            {
                elevator = value;
                NotifyPropertyChanged("Rudder");
            }

        }

        public void NotifyPropertyChanged(String propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public void flightSpecifiecJoystickMode()
        {
            new Thread(delegate ()
            {
                while (disconnect == false)
                {
                    if (Client.client_instance.currentFlightState() == null) continue;
                    string[] flightsInsturment;
                    flightsInsturment = Client.client_instance.currentFlightState().Split(',');
                    this.elevator = Convert.ToDouble(flightsInsturment[this.elevator_idx]);
                    this.aileron = Convert.ToDouble(flightsInsturment[this.aileron_idx]);
                    this.throttle = Convert.ToDouble(flightsInsturment[this.throttle_idx]);
                    this.rudder = Convert.ToDouble(flightsInsturment[this.rudder_idx]);
                    /*this.Flight_speed = Convert.ToDouble(flightsInsturment[speed_index]);
                    this.Altimeter = Convert.ToDouble(flightsInsturment[altimeter_index]);
                    this.Head_deg = Convert.ToDouble(flightsInsturment[headdeg_index]);
                    this.Roll = flightsInsturment[roll_index];
                    this.Yaw = flightsInsturment[yaw_index];
                    this.Pitch = flightsInsturment[pitch_index];
*/                }
            }).Start();
        }
    }
}
