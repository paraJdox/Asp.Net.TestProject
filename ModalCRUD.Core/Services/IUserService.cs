using ModalCRUD.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalCRUD.Core.Services
{
    public interface IUserService
    {
        Task<User> SignUp(User user);
        Task<bool> ValidateUser(User user);
    }
}
