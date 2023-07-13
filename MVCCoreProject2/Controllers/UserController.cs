using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCCoreProject2.Entities;
using MVCCoreProject2.Models;

namespace MVCCoreProject2.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public UserController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<UserViewModel> users = _databaseContext.Users.ToList().Select(x => _mapper.Map<UserViewModel>(x)).ToList();
            return View(users);
        }
    }
}
