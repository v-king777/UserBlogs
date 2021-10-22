using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBlogs.Models.Entities;

namespace UserBlogs.Models.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(User user);

        Task<User[]> GetUsers();
    }
}
