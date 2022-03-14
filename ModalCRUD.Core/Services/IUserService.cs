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
        User SignUp(User user);
        User SignIn(User user);
    }
}
