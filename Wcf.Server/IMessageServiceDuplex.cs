using System.ServiceModel;

namespace Wcf.Server
{
    [ServiceContract(CallbackContract = typeof(IMessageServiceDuplexCallback), SessionMode = SessionMode.Required)]
    public interface IMessageServiceDuplex
    {
        [OperationContract(IsOneWay = true)]
        void SendMessage(string msg);

        [OperationContract(IsOneWay = true)]
        void SendMessageToServer(string msg);

        [OperationContract(IsOneWay = true)]
        void Connect();
    }

    public interface IMessageServiceDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void ForwardMessage(string msg);
    }
}
