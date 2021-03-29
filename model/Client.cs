using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace FlightSimulator2.model
{
    class Client{

        TcpClient tcpClient;
        NetworkStream stream;


        public Client(){
            this.tcpClient = new TcpClient();
            //this.Connect("127.0.0.1", 5400);

        }

        public void Connect(string ip, int port)
        {
            this.tcpClient.Connect(ip, port);
            this.stream = this.tcpClient.GetStream();
        }

        public void Disconnect()
        {
            try
            {
                // Close networkStream.
                this.tcpClient.GetStream().Close();
            }// The networkStream was already closed or something else happen.
            catch (Exception) { }
            try
            {
                // Close tcpClient.
                this.tcpClient.Close();
            }// The tcpclnt was already closed or something else happen.
            catch (Exception) { }
            this.tcpClient = null;
        }

        public void Write(string command)
        {
            if (this.tcpClient != null)
            {
                this.stream = this.tcpClient.GetStream();
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] b = asen.GetBytes(command);
                this.stream.Write(b, 0, b.Length);
            }
        }


        public string Read()
        {
            if (this.tcpClient != null)
            {
                // Time out of 10 seconds.
                this.tcpClient.ReceiveTimeout = 10000;
                this.stream.ReadTimeout = 10000;
                // Only if the ReceiveBufferSize not empty so we want to convert the message to string and return it.
                if (this.tcpClient.ReceiveBufferSize > 0)
                {
                    byte[] bb = new byte[this.tcpClient.ReceiveBufferSize];
                    int k = this.stream.Read(bb, 0, 100);
                    string massage = "";
                    for (int i = 0; i < k; i++)
                    {
                        massage += (Convert.ToChar(bb[i]));
                    }
                    return massage;
                }
            }
            return "ERR";
        }



    }
}
