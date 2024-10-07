//using Microsoft.AspNetCore.SignalR;
//namespace WebApplication1.Hubs
//{
//    public class NotificationHub : Hub
//    {
//        public async Task SendNotification(string message)
//        {
//            // Send notification to all connected clients
//            await Clients.All.SendAsync("ReceiveNotification", message);
//        }
//    }
//}
using Microsoft.AspNetCore.SignalR;

namespace WebApplication1.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendNotification(string message)
        {
            // Send notification to all connected clients
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}







