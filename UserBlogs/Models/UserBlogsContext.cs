using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBlogs.Models.Db;

namespace UserBlogs.Models
{
    public class UserBlogsContext : DbContext
    {
        public UserBlogsContext(DbContextOptions<UserBlogsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<UserPost> UserPosts { get; set; }
    }
}
