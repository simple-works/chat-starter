using System;
using System.Net;
using System.Net.Sockets;

namespace ChatStarterCommon
{
    public class ChatUser : IDisposable
    {
        public Guid ID { get; private set; }
        public string Name { get; private set; }
        public Socket ClientSocket { get; private set; }
        public IPEndPoint ClientEndPoint
        {
            get
            {
                return (ClientSocket.RemoteEndPoint as IPEndPoint);
            }
        }

        public ChatUser(string name, Socket clientSocket)
        {
            this.ID = Guid.NewGuid();
            this.Name = name;
            this.ClientSocket = clientSocket;
        }

        public void Dispose()
        {
            if (ClientSocket != null)
            {
                ClientSocket.Dispose();
            }
        }
    }
}
