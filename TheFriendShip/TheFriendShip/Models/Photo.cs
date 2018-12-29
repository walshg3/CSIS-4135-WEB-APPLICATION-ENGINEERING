using System;

namespace TheFriendShip.Models
{
    public class Photo
    {
        public int ID { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsProfilePic { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}