using System;
using System.Net;
using System.Net.Sockets;

namespace ChatStarterCommon
{
    public class ChatUser
    {
        public Guid ID { get; private set; }
        public string Name { get; set; }
        public Socket ClientSocket { get; set; }
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
    }
}
