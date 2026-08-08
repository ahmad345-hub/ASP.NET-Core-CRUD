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

        public ViewResult Creat()
        {
            return View();
        }


        public ViewResult Create(User Request)
        {
            context.Users.Add(Request);
            context.SaveChanges();
            return View(Creat);
        }



    }
}
