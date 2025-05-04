using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using Module32_MVC.Repositories;
using Module32_MVC.Models.DB;

namespace Module32_MVC.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private void LogConsole(HttpContext context)
        {
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
        }

        private Request LogDB(HttpContext context)
        {
            var newRequest = new Request()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = $"http://{context.Request.Host.Value + context.Request.Path}"
            };
            return newRequest;
        }

        public async Task InvokeAsync(HttpContext context, IRequestRepository repo)
        {
            //LogConsole(context);

            await repo.AddRequest(LogDB(context));

            await _next.Invoke(context);
        }
    }
}
