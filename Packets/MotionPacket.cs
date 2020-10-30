using System;
using System.Collections.Generic;
using System.Text;

namespace F1TelemetryClient
{
    public class MotionPacket: Packet
    {
        //BASE PACKET WITH HEADERS
        //public Packet basePacket;

        //60 BYTES OF CAR MOTION DATA
        public CarMotionData[] gridMotionData { get; set; }
        public WheelData suspensionPosition { get; set; }
        public WheelData suspensionVelocity { get; set; }
        public WheelData suspensionAcceleration { get; set; }
        public WheelData wheelSpeed { get; set; }
        public WheelData wheelSlip { get; set; }
        public float localVelX { get; set; }
        public float localVelY { get; set; }
        public float localVelZ { get; set; }
        public float angularVelX { get; set; }
        public float angularVelY { get; set; }
        public float angularVelZ { get; set; }
        public float angularAccX { get; set; }
        public float angularAccY { get; set; }
        public float angularAccZ { get; set; }
        public float frontWheelAngle { get; set; }





        public MotionPacket(byte[] packetData): base(packetData)
        {

            gridMotionData = new CarMotionData[22];
            //Extract CarMotionData for every car in the grid (22 Cars max)
            /* 
             TODO: SET THE LOOP TO THE NUMBER OF CARS ON TRACK
            for (int i = 0; i < 22; i++)
            {
                gridMotionData[i] = new CarMotionData(baseData, lastIndex);
                lastIndex = gridMotionData[i].lastIndex;
            }
             */


            //Extract Motion Data Left

            byte[] fourByteHelper = new byte[4];
            int index = lastIndex;
            float[] wheelDataHelper = new float[4];

            //SuspensionPosition is 4 bytes (float)fo each wheel (RL,RR,FL,RF)
            for (int i = 0; i < 4; i++)
            {
                for (int j = index; j < index + 4; j++)
                {
                    fourByteHelper[j - index] = baseData[j];
                }
                wheelDataHelper[i] = BitConverter.ToSingle(fourByteHelper, 0);
                index += 4;
            }
            suspensionPosition = new WheelData(wheelDataHelper);

            //SuspensionVelocity is 4 bytes (float)fo each wheel (RL,RR,FL,RF)
            for (int i = 0; i < 4; i++)
            {
                for (int j = index; j < index + 4; j++)
                {
                    fourByteHelper[j - index] = baseData[j];
                }
                wheelDataHelper[i] = BitConverter.ToSingle(fourByteHelper, 0);
                index += 4;
            }
            suspensionVelocity = new WheelData(wheelDataHelper);

            //SuspensionAcceleration is 4 bytes (float)fo each wheel (RL,RR,FL,RF)
            for (int i = 0; i < 4; i++)
            {
                for (int j = index; j < index + 4; j++)
                {
                    fourByteHelper[j - index] = baseData[j];
                }
                wheelDataHelper[i] = BitConverter.ToSingle(fourByteHelper, 0);
                index += 4;
            }
            suspensionAcceleration = new WheelData(wheelDataHelper);

            //WheelSpeed is 4 bytes (float)fo each wheel (RL,RR,FL,RF)
            for (int i = 0; i < 4; i++)
            {
                for (int j = index; j < index + 4; j++)
                {
                    fourByteHelper[j - index] = baseData[j];
                }
                wheelDataHelper[i] = BitConverter.ToSingle(fourByteHelper, 0);
                index += 4;
            }
            wheelSpeed = new WheelData(wheelDataHelper);

            //WheelSlip is 4 bytes (float)fo each wheel (RL,RR,FL,RF)
            for (int i = 0; i < 4; i++)
            {
                for (int j = index; j < index + 4; j++)
                {
                    fourByteHelper[j - index] = baseData[j];
                }
                wheelDataHelper[i] = BitConverter.ToSingle(fourByteHelper, 0);
                index += 4;
            }
            wheelSlip = new WheelData(wheelDataHelper);

            //localVelocityX
            for (int i = 0; i < 4; i++)
            {
                for (int j = index; j < index + 4; j++)
                {
                    fourByteHelper[j - index] = baseData[j];
                }
                localVelX = BitConverter.ToSingle(fourByteHelper, 0);
                index += 4;
            }

            //localVelocityY
            for (int i = 0; i < 4; i++)
            {
                for (int j = index; j < index + 4; j++)
                {
                    fourByteHelper[j - index] = baseData[j];
                }
                localVelY = BitConverter.ToSingle(fourByteHelper, 0);
                index += 4;
            }

            //localVelocityZ
            for (int i = 0; i < 4; i++)
            {
                for (int j = index; j < index + 4; j++)
                {
                    fourByteHelper[j - index] = baseData[j];
                }
                localVelZ = BitConverter.ToSingle(fourByteHelper, 0);
                index += 4;
            }

            //angularVelocityX
            for (int i = 0; i < 4; i++)
            {
                for (int j = index; j < index + 4; j++)
                {
                    fourByteHelper[j - index] = baseData[j];
                }
                angularVelX = BitConverter.ToSingle(fourByteHelper, 0);
                index += 4;
            }

            //angularVelocityy
            for (int i = 0; i < 4; i++)
            {
                for (int j = index; j < index + 4; j++)
                {
                    fourByteHelper[j - index] = baseData[j];
                }
                angularVelY = BitConverter.ToSingle(fourByteHelper, 0);
                index += 4;
            }

            //angularVelocityZ
            for (int i = 0; i < 4; i++)
            {
                for (int j = index; j < index + 4; j++)
                {
                    fourByteHelper[j - index] = baseData[j];
                }
                angularVelZ = BitConverter.ToSingle(fourByteHelper, 0);
                index += 4;
            }

            //angularAccelerationX
            for (int i = 0; i < 4; i++)
            {
                for (int j = index; j < index + 4; j++)
                {
                    fourByteHelper[j - index] = baseData[j];
                }
                angularAccX = BitConverter.ToSingle(fourByteHelper, 0);
                index += 4;
            }

            //angularAccelerationY
            for (int i = 0; i < 4; i++)
            {
                for (int j = index; j < index + 4; j++)
                {
                    fourByteHelper[j - index] = baseData[j];
                }
                angularAccY = BitConverter.ToSingle(fourByteHelper, 0);
                index += 4;
            }

            //angularAccelerationZ
            for (int i = 0; i < 4; i++)
            {
                for (int j = index; j < index + 4; j++)
                {
                    fourByteHelper[j - index] = baseData[j];
                }
                angularAccZ = BitConverter.ToSingle(fourByteHelper, 0);
                index += 4;
            }

            //frontWheelAngle
            for (int i = 0; i < 4; i++)
            {
                for (int j = index; j < index + 4; j++)
                {
                    fourByteHelper[j - index] = baseData[j];
                }
                frontWheelAngle = BitConverter.ToSingle(fourByteHelper, 0);
                index += 4;
            }



        }
    }

    public class CarMotionData
    {
        public float worldPositionX { get; set; }
        public float worldPositionY { get; set; }
        public float worldPositionZ { get; set; }
        public float worldVelocityX { get; set; }
        public float worldVelocityY { get; set; }
        public float worldVelocityZ { get; set; }
        public Int16 worldForwardDirX { get; set; }
        public Int16 worldForwardDirY { get; set; }
        public Int16 worldForwardDirZ { get; set; }
        public Int16 worldRightDirX { get; set; }
        public Int16 worldRightDirY { get; set; }
        public Int16 worldRightDirZ { get; set; }

        public float gForceLateral { get; set; }
        public float gForceLongitudinal { get; set; }
        public float gForceVertical { get; set; }
        public float yaw { get; set; }
        public float pitch { get; set; }
        public float roll { get; set; }

        public int lastIndex;

        public CarMotionData(byte[] data, int index)
        {
           
            byte[] fourByteHelper = new byte[4];
            byte[] twoByteHelper = new byte[2];

            //PositionX
            for (int i = index; i < index+4; i++)
            {
                fourByteHelper[i - index] = data[i];
            }
            worldPositionX = BitConverter.ToSingle(fourByteHelper, 0);
            index += 4;

            //PositionY
            for (int i = index; i < index + 4; i++)
            {
                fourByteHelper[i - index] = data[i];
            }
            worldPositionY = BitConverter.ToSingle(fourByteHelper, 0);
            index += 4;

            //PositionZ
            for (int i = index; i < index + 4; i++)
            {
                fourByteHelper[i - index] = data[i];
            }
            worldPositionZ = BitConverter.ToSingle(fourByteHelper, 0);
            index += 4;

            //VelocityX
            for (int i = index; i < index + 4; i++)
            {
                fourByteHelper[i - index] = data[i];
            }
            worldVelocityX = BitConverter.ToSingle(fourByteHelper, 0);
            index += 4;

            //VelocityY
            for (int i = index; i < index + 4; i++)
            {
                fourByteHelper[i - index] = data[i];
            }
            worldVelocityY = BitConverter.ToSingle(fourByteHelper, 0);
            index += 4;

            //VelocityZ
            for (int i = index; i < index + 4; i++)
            {
                fourByteHelper[i - index] = data[i];
            }
            worldVelocityZ = BitConverter.ToSingle(fourByteHelper, 0);
            index += 4;

            //ForwX
            for (int i = index; i < index + 2; i++)
            {
                twoByteHelper[i - index] = data[i];
            }
            worldForwardDirX = BitConverter.ToInt16(twoByteHelper, 0);
            index += 2;

            //ForwY
            for (int i = index; i < index + 2; i++)
            {
                twoByteHelper[i - index] = data[i];
            }
            worldForwardDirY = BitConverter.ToInt16(twoByteHelper, 0);
            index += 2;

            //ForwZ
            for (int i = index; i < index + 2; i++)
            {
                twoByteHelper[i - index] = data[i];
            }
            worldForwardDirZ = BitConverter.ToInt16(twoByteHelper, 0);
            index += 2;

            //RightDirX
            for (int i = index; i < index + 2; i++)
            {
                twoByteHelper[i - index] = data[i];
            }
            worldRightDirX = BitConverter.ToInt16(twoByteHelper, 0);
            index += 2;

            //RightDirY
            for (int i = index; i < index + 2; i++)
            {
                twoByteHelper[i - index] = data[i];
            }
            worldRightDirY = BitConverter.ToInt16(twoByteHelper, 0);
            index += 2;

            //RightDirZ
            for (int i = index; i < index + 2; i++)
            {
                twoByteHelper[i - index] = data[i];
            }
            worldRightDirZ = BitConverter.ToInt16(twoByteHelper, 0);
            index += 2;

            //GForceLat
            for (int i = index; i < index + 4; i++)
            {
                fourByteHelper[i - index] = data[i];
            }
            gForceLateral = BitConverter.ToSingle(fourByteHelper, 0);
            index += 4;

            //GForceLong
            for (int i = index; i < index + 4; i++)
            {
                fourByteHelper[i - index] = data[i];
            }
            gForceLongitudinal = BitConverter.ToSingle(fourByteHelper, 0);
            index += 4;

            //GForceVertical
            for (int i = index; i < index + 4; i++)
            {
                fourByteHelper[i - index] = data[i];
            }
            gForceVertical = BitConverter.ToSingle(fourByteHelper, 0);
            index += 4;

            //Yaw
            for (int i = index; i < index + 4; i++)
            {
                fourByteHelper[i - index] = data[i];
            }
            yaw = BitConverter.ToSingle(fourByteHelper, 0);
            index += 4;

            //pitch
            for (int i = index; i < index + 4; i++)
            {
                fourByteHelper[i - index] = data[i];
            }
            pitch = BitConverter.ToSingle(fourByteHelper, 0);
            index += 4;

            //roll
            for (int i = index; i < index + 4; i++)
            {
                fourByteHelper[i - index] = data[i];
            }
            roll = BitConverter.ToSingle(fourByteHelper, 0);
            index += 4;

            lastIndex = index;
        }



    }

    public class WheelData
    {
        public float RearLeft { get; set; }
        public float RearRight { get; set; }
        public float FrontLeft { get; set; }
        public float FrontRight { get; set; }

        public WheelData(float[] data)
        {
            RearLeft = data[0];
            RearRight = data[1];
            FrontLeft = data[2];
            FrontRight = data[3];
        }

    }
    
}
