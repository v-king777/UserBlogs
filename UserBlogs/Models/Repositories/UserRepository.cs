using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBlogs.Models.Db;

namespace UserBlogs.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserBlogsContext _context;

        public UserRepository(UserBlogsContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            user.Id = Guid.NewGuid();
            user.JoinDate = DateTime.Now;

            var entry = _context.Entry(user);

            if (entry.State == EntityState.Detached)
            {
                await _context.Users.AddAsync(user);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers()
        {
            return await _context.Users.ToArrayAsync();
        }
    }
}
