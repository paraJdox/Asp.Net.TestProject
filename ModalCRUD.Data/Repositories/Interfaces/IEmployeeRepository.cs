using ModalCRUD.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalCRUD.Data.Repositories.Interfaces
{
    internal interface IEmployeeRepository
    {
        Task<Employee> CreateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> UpdateEmployeeAsync(Employee employee);

    }
}
