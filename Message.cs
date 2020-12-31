
namespace TcpControl
{
    public class CONSTANTS
    {
        // Messasge Type
        public const uint LOGGING_START_STOP = 0x001;
        public const uint SYSTEM_STATUS_INFO = 0x101;
        public const uint UI_MESSAGE_RECEIVE = 0x102;
        public const uint DDS_NETWORK_DATA   = 0x201;
        public const uint RTI_NETWORK_DATA   = 0x301;

        // Message Source
        public const byte FROM_GUI = 0x01;
        public const byte FROM_CUI = 0x02;

        // Send or Response
        public const byte SEND_DATA = 0x01;
        public const byte RESPONSE_DATA = 0x02;

        // Message Type
        public const ushort GUI_TO_CUI_DATA = 0x00;
        public const ushort CUI_INTERNAL_DATA = 0x01;
        public const ushort DDS_RECEIVED_DATA = 0x02;
        public const ushort RTI_SENDED_DATA = 0x03;

        // Message Size

        public const int HEADER_SIZE = 16;
    }

    public interface ISerializable
    {
        byte[] GetBytes();
        int GetSize();
    }

    public class Message : ISerializable
    {
        public Header Header { get; set; }
        public ISerializable Body { get; set; }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];

            Header.GetBytes().CopyTo(bytes, 0);
            Body.GetBytes().CopyTo(bytes, Header.GetSize());
            
            return bytes;
        }

        public int GetSize()
        {
            return Header.GetSize() + Body.GetSize();
        }

        public int GetDataSize()
        {
            return Body.GetSize();
        }
    }
}