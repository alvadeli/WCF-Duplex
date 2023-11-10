using System;
using Wcf.Server;

namespace Wcf.Client
{
    public class MessageServiceDuplexCallback : IMessageServiceDuplexCallback
    {
        public void ForwardMessage(string msg)
        {
            Console.WriteLine($"Client received: {msg}");
        }
    }
}
