using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBlogs.Models.Db;

namespace UserBlogs.Models.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly UserBlogsContext _context;

        public RequestRepository(UserBlogsContext context)
        {
            _context = context;
        }

        public async Task AddRequest(Request request)
        {
            var entry = _context.Entry(request);

            if (entry.State == EntityState.Detached)
            {
                await _context.Requests.AddAsync(request);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests()
        {
            return await _context.Requests.ToArrayAsync();
        }
    }
}
