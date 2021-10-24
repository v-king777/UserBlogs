using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UserBlogs.Models.Db;
using UserBlogs.Models.Repositories;

namespace UserBlogs.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestRepository _repo;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, IRequestRepository repo)
        {
            _next = next;
            _repo = repo;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            LogConsole(context);
            await LogFile(context);
            await LogDb(context);
            await _next.Invoke(context);
        }

        /// <summary>
        /// Логирование в консоль
        /// </summary>
        private void LogConsole(HttpContext context)
        {
            Console.WriteLine($"[{DateTime.Now}]: New request to http://" +
                $"{context.Request.Host.Value + context.Request.Path}");
        }

        /// <summary>
        /// Логирование в файл
        /// </summary>
        private async Task LogFile(HttpContext context)
        {
            string logMessage = $"[{DateTime.Now}]: New request to http://" +
                $"{context.Request.Host.Value + context.Request.Path}{Environment.NewLine}";

            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Logs"));

            string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "RequestLog.txt");

            await File.AppendAllTextAsync(logFilePath, logMessage);
        }

        /// <summary>
        /// Логирование в базу данных
        /// </summary>
        private async Task LogDb(HttpContext context)
        {
            var newRequest = new Request()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = $"http://{context.Request.Host.Value + context.Request.Path}"
            };

            await _repo.AddRequest(newRequest);
        }
    }
}
