using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBlogs.Models.Db;

namespace UserBlogs.Models.Repositories
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
    }
}
