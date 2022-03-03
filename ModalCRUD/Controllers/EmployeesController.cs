using Microsoft.AspNetCore.Mvc;
using ModalCRUD.Data;
using ModalCRUD.Models;

namespace ModalCRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Employee>? listofEmployees = _context.Employee?.ToList();
            return View(listofEmployees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Employee employee = new();

            ViewData["Message"] = "Create";
            // This passes a new employee to the partial view (modal)

            // use this to access a sub folder in Views/Shared/ folders (to organize partial views)
            return PartialView("/Views/Shared/Modals/_UserModalSharedPartial.cshtml", employee);

            // use this if the partial view is just in /Views/Shared/ folder, or in the /Views/ControllerName
            // return PartialView("_UserModalPartial", employee); 
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _context.Employee?.Add(employee);
            _context.SaveChanges();
            // This passes a new employee to the partial view (modal)
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee? employee = _context.Employee?.Where(employeeToEdit => employeeToEdit.Id == id).FirstOrDefault();

            ViewData["Message"] = "Edit";
            // This passes a new employee to the partial view (modal)
            // return PartialView("_EditEmployeeModelPartial", employee);
            return PartialView("_EmployeeModalPartial", employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            _context.Employee?.Update(employee);
            _context.SaveChanges();

            // This passes a new employee to the partial view (modal)
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            Employee? employee = _context.Employee?.Where(e => e.Id == id).FirstOrDefault();

            ViewData["Message"] = "Details";
            // This passes a new employee to the partial view (modal)
            // return PartialView("_DetailEmployeeModelPartial", employee);
            return PartialView("_EmployeeModalPartial", employee);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee? employee = _context.Employee?.Where(employeeToEdit => employeeToEdit.Id == id).FirstOrDefault();

            ViewData["Message"] = "Delete";

            // This passes a new employee to the partial view (modal)
            return PartialView("_EmployeeModalPartial", employee);
        }

        [HttpPost]
        public IActionResult Delete(Employee emp)
        {
            Employee? employee = _context.Employee?.Where(e => e.Id == emp.Id).FirstOrDefault();
            _context.Employee?.Remove(employee!);
            _context.SaveChanges();

            // This passes a new employee to the partial view (modal)
            return RedirectToAction("Index");
        }
    }
}
