using System.Collections.Generic;
using System;

namespace F1TelemetryClient
{
    public class Packet
    {
        public UInt16 packetFormat;             // 2020
        public byte gameMajorVersion;         // Game major version - "X.00"
        public byte gameMinorVersion;         // Game minor version - "1.XX"
        public byte packetVersion;            // Version of this packet type, all start from 1
        public byte packetId;                 // Identifier for the packet type, see below
        public UInt64 sessionUID;               // Unique identifier for the session
        public float sessionTime;              // Session timestamp
        public UInt32 frameIdentifier;          // Identifier for the frame the data was retrieved on
        public byte playerCarIndex;           // Index of player's car in the array

        // ADDED IN BETA 2: 
        public byte secondaryPlayerCarIndex;  // Index of secondary player's car in the array (splitscreen)
                                              // 255 if no second player

        public Packet(byte[] packetData)
        {
            //GET HEADERS

            //GAME (PACKET FORMAT) ARE THE FIRST TO BYTES OF THE PACKET 
            byte[] game = {packetData[0], packetData[1]};
            packetFormat = BitConverter.ToUInt16(game, 0);

            //NEXT DATA IS A SINGLE BYTE EACH
            gameMajorVersion = packetData[2];
            gameMinorVersion = packetData[3];
            packetVersion = packetData[4];
            packetId = packetData[5];

            //8 BITS FOR THE SESSION ID
            byte[] sessArray = new byte[8];
            for (int i = 6; i < 6+8; i++)
            {
                sessArray[i-6] = packetData[i];
            }
            sessionUID = BitConverter.ToUInt64(sessArray, 0);

            //4 BYTES FOR SessionTime
            byte[] sessTimeArray = new byte[4];
            for (int i = 14; i < 14+4; i++)
            {
                sessTimeArray[i-14] = packetData[i];
            }
            sessionTime = BitConverter.ToSingle(sessTimeArray, 0);

            // 4 BYTES FOR FRAME IDENTIFIER
            byte[] frameID = new byte[4];
            for (int i = 18; i < 18 + 4; i++)
            { 
            
                frameID[i-18] = packetData[i];
            }
            frameIdentifier = BitConverter.ToUInt32(frameID, 0);

            //ONE BYTE FOR THE NEXT TWO
            playerCarIndex = packetData[22];
            secondaryPlayerCarIndex = packetData[23];
        }

        public override string ToString()
        {
            string str = string.Format("PACKET INFORMATION ******************* /nGAME: {0} /nVERSION: {1}.{2} /nPACKET VERSION: {3} /nPACKET TYPE: {4} /nSESSION ID: {5} /nSESSION TIME: {6} /nFRAME ID: {7} /nPLAYER CAR INDEX: {8}", packetFormat, gameMajorVersion,gameMinorVersion, packetVersion, getPacketType(), sessionUID, sessionTime, frameIdentifier, playerCarIndex).Replace("/n",Environment.NewLine); ;
            return str;
        }

        public String getPacketType()
        {
            switch (this.packetId)
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

