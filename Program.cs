using F1TelemetryClient;
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

            while (true)
            {
                data = newsock.Receive(ref sender);
                //Console.WriteLine(data.Length);
                Packet packet = new Packet(data);
                //Console.WriteLine(packet.ToString());
                if (packet.getPacketType() == "Motion")
                {
                    MotionPacket motionPacket = new MotionPacket(data);
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("-------------------");
                    Console.WriteLine(motionPacket.carMotionData.worldPositionY);
                }

                
            }
        }
    }
}
