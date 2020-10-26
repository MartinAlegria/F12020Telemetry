using System;
using System.Net;
using System.Net.Sockets;
using System.Text;



namespace F1TelemetryClient
{
    class Program
    {
        public static void Main()
        {
            byte[] data = new byte[1024];
            IPAddress myAddress = IPAddress.Parse("192.168.0.2");
            IPEndPoint ipep = new IPEndPoint(myAddress, 20777);
            UdpClient newsock = new UdpClient(ipep);

            Console.WriteLine("Waiting for a client...");
            Console.WriteLine("Address {0}", myAddress);


            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

            data = newsock.Receive(ref sender);

            Console.WriteLine("Message received from {0}:", sender.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));

            string welcome = "Welcome to my test server";
            data = Encoding.ASCII.GetBytes(welcome);
            newsock.Send(data, data.Length, sender);

            while (true)
            {
                data = newsock.Receive(ref sender);
                //Console.WriteLine(data.Length);
                Packet packet = new Packet(data);
                Console.WriteLine(packet.ToString());

                
            }
        }
    }
}
