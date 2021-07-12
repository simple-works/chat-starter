using System.Net;
using System.Net.Sockets;

namespace ChatStarterCommon
{
    public class ChatClient
    {
        private Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public IPEndPoint LocalEndPoint
        {
            get
            {
                return (_socket.LocalEndPoint as IPEndPoint);
            }
        }
        public IPEndPoint RemoteEndPoint
        {
            get
            {
                return (_socket.RemoteEndPoint as IPEndPoint);
            }
        }

        public ChatClient(IPAddress localIPAddress, int localPort)
        {
            if (!_socket.IsBound)
            {
                _socket.Bind(new IPEndPoint(localIPAddress, localPort));
            }
        }

        public void Connect(IPAddress remoteIPAddress, int remotePort)
        {
            if (!_socket.Connected)
            {
                _socket.Connect(new IPEndPoint(remoteIPAddress, remotePort));
            }
        }

        public void SendText(string text)
        {
            _socket.SendString(text);
        }

        public string ReceiveText()
        {
            return _socket.ReceiveString();
        }

        public void Disconnect()
        {
            if (_socket.Connected)
            {
                _socket.Disconnect(true);
            }
        }
    }
}
