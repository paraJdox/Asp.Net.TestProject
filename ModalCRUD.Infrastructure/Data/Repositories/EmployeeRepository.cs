using Microsoft.EntityFrameworkCore;
using ModalCRUD.Core.Data.Entities;
using ModalCRUD.Core.Data.Repositories;
using ModalCRUD.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalCRUD.Infrastructure.Data.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteAsync(int id)
        {
            Employee? employee = _context.Employee?.Where(e => e.Id == id).FirstOrDefault();
            _context.Employee?.Remove(employee!);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employee.FindAsync(id);
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            _context.Employee?.Update(employee);
            await _context.SaveChangesAsync();

            return employee;
        }
    }
}
