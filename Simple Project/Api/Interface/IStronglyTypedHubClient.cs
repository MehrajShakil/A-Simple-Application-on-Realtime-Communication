namespace Api.Interface
{
    public interface IStronglyTypedHubClient
    {
        Task ReceiveMessage(string message);    
    }
}
