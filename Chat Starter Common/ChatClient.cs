using System.Net;
using System.Net.Sockets;
using System;

namespace ChatStarterCommon
{
    public class ChatClient : IDisposable
    {
        private readonly Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

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

        public void Stop()
        {
            if (_socket.GetIsConnected())
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Disconnect(true);
            }
        }

        public void Dispose()
        {
            if (_socket != null)
            {
                _socket.Dispose();
            }
        }
    }
}
