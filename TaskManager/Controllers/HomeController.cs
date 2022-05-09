using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using TaskManager.Models;
using Task = TaskManager.Models.Task;

namespace TaskManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public Context db = new Context();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult CreateTask(IFormCollection Result)
        {
            Task task = new Task();
            task.header = Result["header"];
            task.content = Result["content"];
            task.priority = (Priority)Enum.Parse(typeof(Priority), Result["priority"]);
            task.createdAt = DateTime.Now;
            task.status = Models.TaskStatus.notStarted;
            task.taskDate = DateTime.ParseExact(Result["date"] + " " + Result["time"], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            db.tasks.Add(task);
            db.SaveChanges();
            return View();
        }

        public IActionResult TaskList()
        {
            var tasks = db.tasks.ToList();
            ViewData["Data"] = tasks;
            return View();
        }


        public IActionResult Fullcalendar()
        {
            return View();
        }
    }
}