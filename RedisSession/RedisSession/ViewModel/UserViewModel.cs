using System;

namespace RedisSession.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
