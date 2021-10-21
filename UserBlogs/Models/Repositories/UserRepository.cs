﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBlogs.Models.Entities;

namespace UserBlogs.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserBlogsContext _context;

        public UserRepository(UserBlogsContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            var entry = _context.Entry(user);

            if (entry.State == EntityState.Detached)
            {
                await _context.Users.AddAsync(user);
            }

            await _context.SaveChangesAsync();
        }
    }
}
