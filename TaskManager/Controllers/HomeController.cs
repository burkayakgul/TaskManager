using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            DateTime today = DateTime.Today;

            var todayTasks = db.tasks.Where(b => b.taskDate.Date == DateTime.Today).OrderBy(c => c.priority).ToList();
            ViewData["TodayTasks"] = todayTasks;

            return View();
        }

        [HttpGet]
        public IActionResult EditTask(int id)
        {
            var task = db.tasks.First(e => e.ID == id);
            ViewData["Data"] = task;
            return View();
        }

        [HttpPost]
        public IActionResult EditTask(IFormCollection data,int id)
        {
            Task task = db.tasks.Find(id);
            task.header = data["header"];
            task.content = data["content"];
            task.status = ((Models.TaskStatus)(int.Parse(data["status"])));
            task.createdAt = DateTime.Now;
            task.taskDate = DateTime.ParseExact(data["date"] + " " + data["time"], "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            db.tasks.Update(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Fullcalendar()
        {
            return View();
        }
    }
}