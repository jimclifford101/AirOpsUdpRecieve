

// dotnet publish -c Release
// dotnet new console -o "ConsoleApplciation2"

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace udplisten
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("UDP Receive Started");
            Console.WriteLine("");          
            fUdpReceive();


        }


        private static void fUdpReceive() {

            bool done = false;

            // AirOps listening for UAS IWG on Port: 10645
            int listenPort = 10645;

            using(var listener = new UdpClient(listenPort))
            {
                IPEndPoint listenEndPoint = new IPEndPoint(IPAddress.Any, 0);
                while(!done)
                {
                    byte[] receivedData = listener.Receive(ref listenEndPoint);

                    //Console.WriteLine("Received broadcast message from client {0}", listenEndPoint.ToString());

                    Console.WriteLine("Msg Received:");
                    Console.WriteLine(Encoding.ASCII.GetString(receivedData)); //should be IWG String sent from above client
                    Console.WriteLine(" ");
                }
            }

        }

 
    }

}
