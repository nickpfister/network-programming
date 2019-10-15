using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkProgramming
{
    /// <summary>
    /// Basic example of listening with a socket, based off of Microsoft docs. Works synchronously.
    /// </summary>
    public static class ListeningWithSocketsExample
    {
        /// <summary>
        /// Starts listening on the local host with the given port.
        /// </summary>
        /// <param name="port">The port to listen to.</param>
        public static void StartListening(int port)
        {
            // Determine the local IP address of the machine/server
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress iPAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(iPAddress, port);

            // Setup a socket and associate it with the local endpoint
            Socket listener = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);

            // A max of 100 connections can be made here.
            listener.Listen(100);

            Console.WriteLine($"Listening on {iPAddress.ToString()}:{port}");
            Console.WriteLine("Waiting for a connection...");
            // This will sit here and wait for a connection to be made synchronously.
            Socket handler = listener.Accept();
            Console.WriteLine("Connection made!");
            string data = null;
            byte[] bytes;
            while (true)
            {
                // Listen for any messages to be received
                bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                // When there's a period, stop listening.
                if (data.IndexOf(".") > -1)
                {
                    break;
                }
            }

            Console.WriteLine($"Text received: {data}");

            handler.Close();
        }
    }
}
