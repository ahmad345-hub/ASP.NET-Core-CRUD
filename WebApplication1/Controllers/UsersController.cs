using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

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



    }
}
