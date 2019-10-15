using System;
using System.Net;
using System.Net.Sockets;

namespace NetworkProgramming
{
    public static class ClientSocketsExample
    {
        public static void ConnectToSocket(string hostName)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPHostEntry ipHostInfo = Dns.GetHostEntry(hostName);
            IPAddress iPAddress = ipHostInfo.AddressList[0];
            IPEndPoint ipe = new IPEndPoint(iPAddress, 11000);

            try
            {
                s.Connect(ipe);
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine("ArgumentNullException : {0}", ae.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }
    }
}
