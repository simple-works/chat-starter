using System;
using System.Net;
using System.Net.Sockets;

namespace ChatStarterCommon
{
    public static class Network
    {
        public static IPAddress GetLocalIPAddress()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ipAddress in hostEntry.AddressList)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ipAddress;
                }
            }
            return IPAddress.Parse("127.0.0.1");
        }

        public static bool TryParseIPAddress(string @string, out IPAddress ipAddress)
        {
            return IPAddress.TryParse(@string.Trim(), out ipAddress);
        }

        public static bool TryParsePort(string @string, out int port)
        {
            if (!int.TryParse(@string.Trim(), out port) || port < 0 || port > 65535)
            {
                port = 0;
                return false;
            }
            return true;
        }

        public static string GenerateIPAddressString(string ipAddressStringMask = "x.x.x.x",
            string randomPartSymbol = "x")
        {
            try
            {
                IPAddress.Parse(ipAddressStringMask.Replace(randomPartSymbol, "0"));
            }
            catch (Exception)
            {
                return "0.0.0.0";
            }

            Random random = new Random();
            Func<string> getRandomOctet = () => random.Next(1, 256).ToString();

            string[] ipAddressStringParts = ipAddressStringMask.Split('.');
            for (int i = 0; i < ipAddressStringParts.Length; i++)
            {
                if (ipAddressStringParts[i] == randomPartSymbol)
                {
                    ipAddressStringParts[i] = getRandomOctet();
                }
            }

            return string.Join(".", ipAddressStringParts);
        }

        public static int GeneratePort(int min = 0, int max = 65535)
        {
            if (min < 0) min = 0;
            if (min > max) min = max;
            if (max > 65535) max = 65535;
            if (max < min) max = min;
            return new Random().Next(min, max + 1);
        }
    }
}
