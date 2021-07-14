using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace ChatStarterCommon
{
    public class ChatServer : IDisposable
    {
        private readonly Socket _socket;

        public List<ChatUser> Users { get; private set; }
        public IPEndPoint EndPoint
        {
            get
            {
                return (_socket.LocalEndPoint as IPEndPoint);
            }
        }

        public ChatServer(IPAddress localIPAddress, int localPort)
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(new IPEndPoint(localIPAddress, localPort));
            Users = new List<ChatUser>();
        }

        public void Listen()
        {
            _socket.Listen(128);
        }

        public ChatUser AcceptUser()
        {
            Socket clientSocket = _socket.Accept();
            string userName = clientSocket.ReceiveString();
            ChatUser user = new ChatUser(userName, clientSocket);
            Users.Add(user);
            return user;
        }

        public string ReceiveText(Guid userID)
        {
            ChatUser user = Users.Find(chatUser => chatUser.ID.Equals(userID));
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }
            return user.ClientSocket.ReceiveString();
        }

        public void BroadcastText(string text)
        {
            foreach (ChatUser user in Users)
            {
                user.ClientSocket.SendString(text);
            }
        }

        public void Stop(bool close = false)
        {
            if (close)
            {
                Dispose();
                return;
            }
            _socket.Close();
            foreach (ChatUser user in Users)
            {
                if (user.ClientSocket.GetIsConnected())
                {
                    user.ClientSocket.Shutdown(SocketShutdown.Both);
                    user.ClientSocket.Close();
                }
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
                if (_socket != null)
                {
                    _socket.Close();
                }
                foreach (ChatUser user in Users)
                {
                    user.ClientSocket.Close();
                }
            }
        }
    }
}
