using Microsoft.EntityFrameworkCore;
using ModalCRUD.Data.Contexts;
using ModalCRUD.Data.Models;
using ModalCRUD.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalCRUD.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            _context.Employee?.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            Employee? employee = _context.Employee?.Where(e => e.Id == id).FirstOrDefault();
            _context.Employee?.Remove(employee!);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employee.FindAsync(id);
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _context.Employee?.Update(employee);
            await _context.SaveChangesAsync();

            return employee;
        }
    }
}
