using System.Collections.Generic;
using System;

namespace F1TelemetryClient
{
    public class Packet
    {
        public static UInt16 packetFormat;             // 2020
        public static byte gameMajorVersion;         // Game major version - "X.00"
        public static  byte gameMinorVersion;         // Game minor version - "1.XX"
        public static byte packetVersion;            // Version of this packet type, all start from 1
        public static byte packetId;                 // Identifier for the packet type, see below
        public static UInt64 sessionUID;               // Unique identifier for the session
        public static float sessionTime;              // Session timestamp
        public static UInt32 frameIdentifier;          // Identifier for the frame the data was retrieved on
        public static byte playerCarIndex;           // Index of player's car in the array

        // ADDED IN BETA 2: 
        public byte secondaryPlayerCarIndex;  // Index of secondary player's car in the array (splitscreen)
                                          // 255 if no second player
      
        public Packet(byte[] packetData)
        {
            packetFormat = packetData[1];
            gameMajorVersion = packetData[2];
            gameMinorVersion = packetData[3];
            packetVersion = packetData[4];
            packetId = packetData[5];
            sessionUID = packetData[6];
            sessionTime = packetData[7];
            frameIdentifier = packetData[8];
            playerCarIndex = packetData[9];
            secondaryPlayerCarIndex = packetData[10];
        }

        public String getPacketType()
        {
            switch (packetId)
            {
                case 0:
                    return "Motion";
                case 1:
                    return "Session";
                case 2:
                    return "LapData";
                case 3:
                    return "Event";
                case 4:
                    return "Participants";
                case 5:
                    return "CarSetups";
                case 6:
                    return "CarTelemetry";
                case 7:
                    return "CarStatus";
                case 8:
                    return "FinalClassification";
                case 9:
                    return "LobbyInfo";
                default:
                    return "UnkownType";
            }
        }


    }
}

