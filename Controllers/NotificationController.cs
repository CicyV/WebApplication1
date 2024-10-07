//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.SignalR;
//using WebApplication1.Hubs;

//namespace WebApplication1.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class NotificationController : Controller
//    {
//        private readonly IHubContext<NotificationHub> _hubContext;
//        //public IActionResult Index()
//        //{
//        //    return View();
//        //}
//        public NotificationController(IHubContext<NotificationHub> hubContext)
//        {
//            _hubContext = hubContext;
//        }

//        [HttpPost("send")]
//        public async Task<IActionResult> SendNotification([FromBody] string message)
//        {
//            // Send the message to all clients
//            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
//            return Ok(new { Message = "Notification sent successfully!" });
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApplication1.Hubs;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return BadRequest(new { Message = "Message cannot be empty." });
            }

            // Send the notification message to all connected clients via SignalR
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
            return Ok(new { Message = "Notification sent successfully!" });
        }


    }
}
