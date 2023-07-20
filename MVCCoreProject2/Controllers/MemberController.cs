using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCCoreProject2.Entities;
using MVCCoreProject2.Helpers;
using MVCCoreProject2.Models;

namespace MVCCoreProject2.Controllers
{
    [Authorize(Roles = "admin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class MemberController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        private readonly IHasher _hasher;

        public MemberController(DatabaseContext databaseContext, IMapper mapper, IHasher hasher)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _hasher = hasher;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MemberListPartial()
        {
            List<UserViewModel> users = _databaseContext.Users.ToList().Select(x => _mapper.Map<UserViewModel>(x)).ToList();
            return PartialView("_MemberListPartial", users);
        }

        public IActionResult AddNewUserPartial()
        {
            return PartialView("_AddNewUserPartial", new CreateUserModel());
        }

        [HttpPost]
        public IActionResult AddNewUser(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Username), "Username is already exists.");
                    return View(model);
                }
                User user = _mapper.Map<User>(model);
                _hasher.DoMD5HashedString(user.Password);
                _databaseContext.Users.Add(user);
                _databaseContext.SaveChanges();

                return PartialView("_AddNewUserPartial", new CreateUserModel {Done = "User has been added successfully" });

            }

            return PartialView("_AddNewUserPartial", model);
        }

        public IActionResult EditUserPartial(Guid id)
        {
            User user = _databaseContext.Users.Find(id);
            EditUserModel model = _mapper.Map<EditUserModel>(user);

            return PartialView("_EditUserPartial", model);
        }

        [HttpPost]
        public IActionResult EditUser(Guid id, EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower() && x.Id != id))
                {
                    ModelState.AddModelError(nameof(model.Username), "Username is already exists.");
                    return PartialView("_EditUserPartial",model);
                }
                User user = _databaseContext.Users.Find(id);
                _mapper.Map(model, user);
                _databaseContext.SaveChanges();

                return PartialView("_EditUserPartial", new EditUserModel { Done = "User has been updated successfully" });
            }
            return PartialView("_EditUserPartial", model);
        }

        public IActionResult DeleteUser(Guid id)
        {
            User user = _databaseContext.Users.Find(id);
            if (user != null)
            {
                _databaseContext.Users.Remove(user);
                _databaseContext.SaveChanges();
            }

            return MemberListPartial();
        }
    }
}
