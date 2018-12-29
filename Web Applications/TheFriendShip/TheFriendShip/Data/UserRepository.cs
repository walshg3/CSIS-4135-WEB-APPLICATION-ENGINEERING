using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFriendShip.Models;

namespace TheFriendShip.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly TFS_UserContext _context;

        public UserRepository(TFS_UserContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(string id)
        {
            var user = await _context.Users
               .FirstOrDefaultAsync(u => u.Id == id);
            return (User) user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = (from u in _context.Users
                         select u).AsQueryable().ToListAsync();
            return (IEnumerable<User>) users;
        }

        public async Task<bool> SaveAll()
        {
            var numberOfChanges = await _context.SaveChangesAsync();
            return (numberOfChanges > 0);
        }
    }
}
