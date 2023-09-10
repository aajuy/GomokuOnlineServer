﻿namespace GameServer.Web.Data.DTOs
{
    public class SaveMatchResultRequestDto
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Result { get; set; }
        public int[] UserIds { get; set; }
        public string[] Usernames { get; set; }
        public string ServerName { get; set; }
        public string ServerSessionId { get; set; }
    }
}
