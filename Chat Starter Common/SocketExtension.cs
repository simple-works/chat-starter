using System;
using System.Net.Sockets;
using System.Text;

namespace ChatStarterCommon
{
    public static class SocketExtension
    {
        public static bool GetIsConnected(this Socket socket)
        {
            bool socketBlockingValueBackup = socket.Blocking;
            try
            {
                byte[] testBuffer = new byte[1];
                socket.Blocking = false;
                socket.Send(testBuffer, 0, 0);
                socket.Blocking = socketBlockingValueBackup;
                return true;
            }
            catch (SocketException socketException)
            {
                socket.Blocking = socketBlockingValueBackup;
                return socketException.NativeErrorCode.Equals(10035); // WSAEWOULDBLOCK (10035): Resource temporarily unavailable.
            }
        }

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
