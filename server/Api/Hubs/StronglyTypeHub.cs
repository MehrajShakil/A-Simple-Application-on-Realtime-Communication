using Api.Interface;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs;

public class StronglyTypeHub : Hub<IStronglyTypedHubClient>
{
    public async Task BroadcastMessage(string message)
    {
        await Clients.All.ReceiveMessage(message);
    }
}

