using Microsoft.AspNetCore.Mvc;
using ModalCRUD.Core.Data.Entities;
using ModalCRUD.Core.Data.Repositories;
using ModalCRUD.Core.Services;
using ModalCRUD.ViewModels;
using System.Diagnostics;

namespace ModalCRUD.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserController(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userRepository.GetAllAsync());
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(User user)
        {
            if (await _userService.SignUpAsync(user) == null)
            {
                ViewBag.Notification = "This account already exists...";
                return View();
            }

            HttpContext.Session.SetString("Id", user.Id.ToString());
            HttpContext.Session.SetString("Username", user.Username);

            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.IsAvailable)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            var userIsValid = await _userService.ValidateUserAsync(user);

            if (!userIsValid)
            {
                ViewBag.Notification = "Wrong Username or Password...";
                return View();
            }

            HttpContext.Session.SetString("Id", user.Id.ToString());
            HttpContext.Session.SetString("Username", user.Username);

            return RedirectToAction("Index");
        }
    }
}
