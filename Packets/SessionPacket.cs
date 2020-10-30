using System;
using System.Collections.Generic;
using System.Text;

namespace F1TelemetryClient
{
    public class SessionPacket : Packet
    {
        //BASE PACKET HEADERS

        byte weather { get; set; } // 0 = clear, 1 = light cloud, 2 = overcast 3 = light rain, 4 = heavy rain, 5 = storm
        sbyte trackTemp { get; set; } // Track temp. in degrees celsius
        sbyte airTemp { get; set; } // Air temp. in degrees celsius
        byte totalLaps { get; set; } // Total number of laps in this race
        UInt16 trackLength { get; set; } // Track length in metres
        byte sessionType { get; set; } // 0 = unknown, 1 = P1, 2 = P2, 3 = P3, 4 = Short P  5 = Q1, 6 = Q2, 7 = Q3, 8 = Short Q, 9 = OSQ 10 = R, 11 = R2, 12 = Time Trial
        sbyte trackID { get; set; } //0-21 for tracks
        byte formula { get; set; } //0 = Modern, 1 = Classic, 2= F2, 3 = F1 Generic
        UInt16 sessionTimeLeft { get; set; } //Time left in session in seconds
        UInt16 sessionDuration { get; set; } //Duration in seconds
        byte pitSpeedLimit { get; set; } //Speed Limit in KPH
        byte paused { get; set; }
        byte isSpectating { get; set; }
        byte spectatorCarIndex { get; set; }
        byte numMarshalZones { get; set; } //Number of marshal 
        byte sliProNativeSupport { get; set; } // SLI Pro support, 0 = inactive, 1 = active
        MarshalZone[] marshalZones { get; set; } //Dependant on numMarshalZones. Max 21
        byte safetyCarStatus { get; set; }  // 0 = no safety car, 1 = full safety car  2 = virtual safety car 0 = 
        byte networkGame { get; set; } //offline, 1 = online
        byte numWeatherForecastSamples { get; set; } //Number of weather samples

        WeatherForecast[] weatherSamples { get; set; } //Array of weather forecast samples, dependent on the above

        public SessionPacket(byte[] packetData) : base(packetData)
        {
            Console.WriteLine("Lol");
        }



    }

    public class MarshalZone
    {

    }

    public class WeatherForecast
    {

    }
}
