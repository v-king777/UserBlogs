using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserBlogs.Models.Db
{
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime JoinDate { get; set; }
    }
}
