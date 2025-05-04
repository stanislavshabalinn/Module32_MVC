using Microsoft.AspNetCore.Mvc;
using Module32_MVC.Repositories;
using System.Threading.Tasks;

namespace Module32_MVC.Controllers
{
    public class LogsController : Controller
    {
        private readonly IRequestRepository _requestLog;

        public LogsController(IRequestRepository requestLog)
        {
            _requestLog = requestLog;
        }

        public async Task <IActionResult> Index()
        {
            var requestLogs = await _requestLog.GetRequests();
            return View(requestLogs);
        }
    }
}
