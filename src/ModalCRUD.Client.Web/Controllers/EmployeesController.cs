﻿using Microsoft.AspNetCore.Mvc;
using ModalCRUD.Core.Data.Entities;
using ModalCRUD.Core.Data.Repositories;

namespace ModalCRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _employeeRepository.GetAllAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var employee = new Employee();

            ViewData["Message"] = "Create";
            // This passes a new employee to the partial view (modal)

            // use this to access a sub folder in Views/Shared/ folders (to organize partial views)
            return PartialView("_EmployeeModalPartial", employee);

            // use this if the partial view is just in /Views/Shared/ folder, or in the /Views/ControllerName
            // return PartialView("_UserModalPartial", employee); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            await _employeeRepository.CreateAsync(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            ViewData["Message"] = "Edit";
            // This passes a new employee to the partial view (modal)
            // return PartialView("_EditEmployeeModelPartial", employee);
            return PartialView("_EmployeeModalPartial", employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            ViewData["Message"] = "Details";
            // This passes a new employee to the partial view (modal)
            // return PartialView("_DetailEmployeeModelPartial", employee);
            return PartialView("_EmployeeModalPartial", employee);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            ViewData["Message"] = "Delete";

            // This passes a new employee to the partial view (modal)
            return PartialView("_EmployeeModalPartial", employee);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee employee)
        {
            await _employeeRepository.DeleteAsync(employee.Id);
            return RedirectToAction("Index");
        }
    }
}
