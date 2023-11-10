using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wcf.Server;

namespace Wcf.Client
{

    internal class Program
    {
        static void Main(string[] args)
        {
            string address = "net.tcp://localhost:6565/MessageService";
            var callBack = new InstanceContext(new MessageServiceDuplexCallback());
            var binding = new NetTcpBinding(SecurityMode.None);
            var endPoint = new EndpointAddress(address);    
            var channel = new DuplexChannelFactory<IMessageServiceDuplex>(callBack,binding);
            var proxy = channel.CreateChannel(endPoint);
            
            proxy?.Connect();

            proxy?.SendMessageToServer("Hello From Client");

            Console.WriteLine("Client is listening. Press Enter to stop.");
            Console.ReadLine();
            
        }
    }
}
