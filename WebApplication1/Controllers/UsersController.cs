using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public ViewResult Index()
        {
            var Users = context.Users.ToList();
            return View(Users);
        }

        // GET: Users/Create
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public IActionResult Create(User Request)
        {
            if (!ModelState.IsValid)
            {
                return View(Request);
            }

            context.Users.Add(Request);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ViewResult Details(int id)
        {
            var user = context.Users.Find(id);

            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = context.Users.Find(id);

            if (user == null)
                return NotFound();

            context.Users.Remove(user);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = context.Users.Find(id);

            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            context.Users.Update(user);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}