using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace ChatStarterCommon
{
    public class ChatServer
    {
        private Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public List<ChatUser> Users = new List<ChatUser>();
        public IPEndPoint EndPoint
        {
            get
            {
                return (_socket.LocalEndPoint as IPEndPoint);
            }
        }

        public ChatServer(IPAddress localIPAddress, int localPort)
        {
            if (!_socket.IsBound)
            {
                _socket.Bind(new IPEndPoint(localIPAddress, localPort));
            }
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

        public void Stop()
        {
            if (_socket.Connected)
            {
                _socket.Disconnect(true);
            }
        }
    }
}
