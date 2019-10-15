using System;
using System.Net;

namespace NetworkProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine($"Application running with argument: {args[0]}");
                switch (args[0])
                {
                    case "webrequest":
                        WebRequestExample.GetWebPage("https://docs.microsoft.com/dotnet/");
                        break;
                    case "socket":
                        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                        IPAddress iPAddress = ipHostInfo.AddressList[0];
                        ClientSocketsExample.ConnectToSocket(iPAddress, 11000);
                        break;
                    case "listen":
                        ListeningWithSocketsExample.StartListening(11000);
                        break;

                }
            }

        }
    }
}
