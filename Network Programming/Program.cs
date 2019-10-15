using System;

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
                        ClientSocketsExample.ConnectToSocket("docs.microsoft.com");
                        break;

                }
            }

        }
    }
}
