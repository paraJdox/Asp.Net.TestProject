using Microsoft.AspNetCore.Mvc;
using ModalCRUD.Core.Data.Entities;
using ModalCRUD.Core.Data.Repositories;
using System.Diagnostics;

namespace ModalCRUD.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _context;

        public UserController(IUserRepository context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAllAsync());
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
            if (await _context.UsernameExists(user.Username))
            {
                ViewBag.Notification = "This account already exists...";
                return View();
            }

            await _context.CreateAsync(user);

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
            var validateUser = await _context.ValidateUserAsync(user);

            if (validateUser == null)
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
