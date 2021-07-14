using System.Net;
using System.Net.Sockets;
using System;

namespace ChatStarterCommon
{
    public class ChatClient : IDisposable
    {
        private readonly Socket _socket;

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
        public bool IsConnected
        {
            get
            {
                return _socket.GetIsConnected();
            }
        }

        public ChatClient(IPAddress localIPAddress, int localPort)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(new IPEndPoint(localIPAddress, localPort));
        }

        public void Connect(IPAddress remoteIPAddress, int remotePort)
        {
            _socket.Connect(new IPEndPoint(remoteIPAddress, remotePort));
        }

        public void SendText(string text)
        {
            _socket.SendString(text);
        }

        public string ReceiveText()
        {
            return _socket.ReceiveString();
        }

        public void Disconnect(bool close = false)
        {
            if (close)
            {
                Dispose();
                return;
            }
            if (_socket.GetIsConnected())
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Disconnect(true);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _socket.Close();
            }
        }
    }
}
