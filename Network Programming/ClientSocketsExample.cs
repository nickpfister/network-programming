using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkProgramming
{
    public static class ClientSocketsExample
    {
        /// <summary>
        /// Overloaded method which resolves a host name.
        /// </summary>
        /// <param name="hostName"></param>
        /// <param name="port"></param>
        public static void ConnectToSocket(string hostName, int port)
        {

            IPHostEntry ipHostInfo = Dns.GetHostEntry(hostName);
            IPAddress iPAddress = ipHostInfo.AddressList[0];
            ConnectToSocket(iPAddress, port);

        }

        /// <summary>
        /// Connect to a socket at a given ip and port.
        /// </summary>
        /// <param name="iPAddress"></param>
        /// <param name="port"></param>
        public static void ConnectToSocket(IPAddress iPAddress, int port)
        {
            Socket s = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipe = new IPEndPoint(iPAddress, port);
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
            while (true)
            {
                // This allows the user to send a sentence through the socket.
                string line = Console.ReadLine();
                s.Send(Encoding.ASCII.GetBytes(line));
                if (line.IndexOf(".") > -1)
                {
                    s.Close();
                    break;
                }
            }
        }
    }
}
