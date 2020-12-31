using System;
using TcpControl;

namespace TcpControl
{
    public class Header : ISerializable
    {
        public UInt16 MESSAGE_ID { get; set; }
        public UInt16 MESSAGE_SIZE { get; set; }
        public Byte SOURCE_ID { get; set; }
        public Byte MESSAGE_CLASS { get; set; }
        public UInt16 MESSAGE_TYPE { get; set; }
        public UInt32 SYSTEM_TIME { get; set; }

        public Header() 
        { 

        }

        public Header (byte[] bytes)
        {
            MESSAGE_ID      = BitConverter.ToUInt16(bytes, 0);
            MESSAGE_SIZE    = BitConverter.ToUInt16(bytes, 2);
            SOURCE_ID       = bytes[4];
            MESSAGE_CLASS   = bytes[5];
            MESSAGE_TYPE    = BitConverter.ToUInt16(bytes, 6);
            SYSTEM_TIME     = BitConverter.ToUInt32(bytes, 8);
        }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[16];

            byte[] temp = BitConverter.GetBytes(MESSAGE_ID);
            Array.Copy(temp, 0, bytes, 0, temp.Length);
            return bytes;
        }

        public int GetSize()
        {
            int DataSize = 0;

            return DataSize;
        }

    }
}