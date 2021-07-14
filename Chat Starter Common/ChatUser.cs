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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (ClientSocket != null)
                {
                    ClientSocket.Close();
                }
            }
            ID = default(Guid);
            Name = default(string);
        }

        public override string ToString()
        {
            return string.Format("{0}@{1}:{2}", Name, ClientEndPoint.Address, ClientEndPoint.Port);
        }
    }
}
