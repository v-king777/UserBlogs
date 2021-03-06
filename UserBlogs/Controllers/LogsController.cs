using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UserBlogs.Models;
using UserBlogs.Models.Repositories;

namespace UserBlogs.Controllers
{
    public class LogsController : Controller
    {
        private readonly IRequestRepository _repo;

        public LogsController(IRequestRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var logs = await _repo.GetRequests();

            return View(logs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
