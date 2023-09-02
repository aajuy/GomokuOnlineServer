using GameServer.Web.Data.DTOs.LoginServer;
using Microsoft.AspNetCore.Mvc;
using Server.Session;

namespace GameServer.Web.Controllers
{
    [ApiController]
    [Route("session")]
    public class SessionController : ControllerBase
    {
        [HttpPost("kickout")]
        public IActionResult Kickout(KickoutRequestDto kickoutRequestDto)
        {
            int userId = kickoutRequestDto.UserId;
            string sessionId = kickoutRequestDto.SessionId;

            //Console.WriteLine($"Kickout UserId:{userId} SessionId:{sessionId}");

            ClientSession? session = SessionManager.Instance.Find(userId);
            if (session != null)
            {
                SessionManager.Instance.Remove(userId);
                session.Disconnect();
                session.Room = null;
            }
            return Ok();
        }
    }
}