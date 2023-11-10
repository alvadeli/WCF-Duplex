using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wcf.Server
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var uris = new Uri[1];
            string address = "net.tcp://localhost:6565/MessageService";
            uris[0] = new Uri(address);
            IMessageServiceDuplex message = new MessageServiceDuplex();
            ServiceHost host = new ServiceHost(message, uris);
            var binding = new NetTcpBinding(SecurityMode.None);

            host.AddServiceEndpoint(typeof(IMessageServiceDuplex), binding, "");

            host.Opened += Host_Opened;
            host.Open();

            Thread.Sleep(1000);


            // Invoke the callback method to send a message to the client
            message.SendMessage("Hello from Server");
            Console.ReadLine();
        }

        private static void Host_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Message service started");
        }
    }
}
