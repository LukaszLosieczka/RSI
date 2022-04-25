using System;
using System.Net;
using System.Net.Sockets;

namespace MyData
{
    class MyData
    {
        private static string GetIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static void Info()
        {
            Console.WriteLine($"Date: {DateTime.Now}");
            Console.WriteLine($"User name: {Environment.UserName}");
            Console.WriteLine($"OS name: {Environment.OSVersion}");
            Console.WriteLine($".NET version: {Environment.Version}");
            Console.WriteLine($"IP address: {GetIP()}");

        }
    }
}