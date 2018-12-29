using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TheFriendShip.Models
{
    public class User : IdentityUser
    {
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public virtual ICollection<Photo> Photos { get;  set; }
        public User()
        {
            Photos = new Collection<Photo>();
        }
    }
}