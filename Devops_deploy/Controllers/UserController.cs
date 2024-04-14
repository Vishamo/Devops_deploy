using Devops_deploy.Models;
using Microsoft.AspNetCore.Mvc;

namespace Devops_deploy.Controllers
{ 
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserInfo userInfo)
        {
            return View("Display", userInfo);
        }
    }
}
