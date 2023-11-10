using System;
using System.ServiceModel;

namespace Wcf.Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MessageServiceDuplex : IMessageServiceDuplex
    {

        private IMessageServiceDuplexCallback _callback = null;

        public MessageServiceDuplex() 
        {
            //_callback = OperationContext.Current.GetCallbackChannel<IMessageServiceDuplexCallback>();
        }

        public void Connect()
        {
            _callback = OperationContext.Current.GetCallbackChannel<IMessageServiceDuplexCallback>();
        }

        public void SendMessage(string msg)
        {
            _callback.ForwardMessage(msg);
        }

        public void SendMessageToServer(string msg)
        {
            Console.WriteLine($"Server received: {msg}");
        }
    }
}
