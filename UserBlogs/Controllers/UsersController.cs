using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBlogs.Models.Entities;
using UserBlogs.Models.Repositories;

namespace UserBlogs.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _repo;

        public UsersController(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _repo.GetUsers();

            return View(authors);
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }
    }
}
