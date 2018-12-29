using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheFriendShip.Data;
using TheFriendShip.Models;

namespace TheFriendShip.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    // [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserRepository _users;
        private readonly IConfiguration _conf;

        public UsersController(IUserRepository users, IConfiguration conf)
        {
            _users = users;
            _conf = conf;
        }

        [HttpGet("getusers")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _users.GetUsers();
            return users;
        }

        [HttpGet("getuser/{id}")]
        public async Task<User> GetUser(string id)
        {
            var user = await _users.GetUser(id);
            return user;
        }
    }
}