using System;
using System.Net.Sockets;
using System.Text;

namespace ChatStarterCommon
{
    public static class SocketExtension
    {
        public static string ReceiveString(this Socket socket)
        {
            byte[] buffer = new byte[socket.ReceiveBufferSize];
            int size = socket.Receive(buffer);
            Array.Resize<byte>(ref buffer, size);
            return Encoding.ASCII.GetString(buffer);
        }

        public static void SendString(this Socket socket, string @string)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(@string);
            socket.Send(buffer);
        }
    }
}
