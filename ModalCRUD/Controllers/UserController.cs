using Microsoft.AspNetCore.Mvc;
using ModalCRUD.Data;
using ModalCRUD.Data.Models;
using System.Diagnostics;

namespace ModalCRUD.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.User.ToList());
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult SignUp(User user)
        //{
        //    if (_context.User.Any(u => u.Username == user.Username))
        //    {
        //        ViewBag.Notification = "This account already exists...";
        //        return View();
        //    }

        //    _context.User.Add(user);
        //    _context.SaveChanges();

        //    HttpContext.Session.SetString("Id", user.Id.ToString());
        //    HttpContext.Session.SetString("Username", user.Username);

        //    return RedirectToAction("Index");
        //}

        //public IActionResult Logout()
        //{
        //    if (HttpContext.Session.IsAvailable)
        //    {
        //        HttpContext.Session.Clear();
        //        return RedirectToAction("Index", "Home");
        //    }

        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Login(User user)
        //{
        //    var validateUser = _context.User.Where(u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password)).FirstOrDefault();

        //    if (validateUser == null)
        //    {
        //        ViewBag.Notification = "Wrong Username or Password...";
        //        return View();
        //    }

        //    HttpContext.Session.SetString("Id", user.Id.ToString());
        //    HttpContext.Session.SetString("Username", user.Username);

        //    return RedirectToAction("Index");
        //}
    }
}
