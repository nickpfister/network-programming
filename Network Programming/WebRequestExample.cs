using System;
using System.IO;
using System.Net;

namespace NetworkProgramming
{
    public static class WebRequestExample
    {
        public static void GetWebPage(string uri)
        {
            WebRequest request = WebRequest.Create(uri);
            WebResponse response = request.GetResponse();
            Console.WriteLine("Status: " + ((HttpWebResponse)response).StatusDescription);

            // Block makes sure the stream gets closed.
            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                Console.WriteLine(responseFromServer);
            }
        }
    }
}
