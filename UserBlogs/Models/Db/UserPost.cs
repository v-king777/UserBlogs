using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserBlogs.Models.Db
{
    [Table("UserPosts")]
    public class UserPost
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
