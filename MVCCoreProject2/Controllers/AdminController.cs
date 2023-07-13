using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCCoreProject2.Controllers
{
    //[Authorize(Roles = "admin,manager")]
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
