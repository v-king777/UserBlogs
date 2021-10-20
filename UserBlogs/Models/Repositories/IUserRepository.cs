using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBlogs.Models.Db;

namespace UserBlogs.Models.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(User user);
    }
}
