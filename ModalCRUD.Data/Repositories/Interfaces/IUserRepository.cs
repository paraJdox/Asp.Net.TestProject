using ModalCRUD.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalCRUD.Data.Repositories.Interfaces
{
    internal interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<bool> UsernameExists(string username);
        Task<User> ValidateUserAsync(User inputUser);
    }
}
