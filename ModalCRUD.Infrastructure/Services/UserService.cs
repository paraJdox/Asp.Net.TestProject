using ModalCRUD.Core.Data.Entities;
using ModalCRUD.Core.Data.Repositories;
using ModalCRUD.Core.Extensions;
using ModalCRUD.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalCRUD.Infrastructure.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> SignUp(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ValidateUser(User user)
        {
            if (await _userRepository.UsernameExists(user.Username) && user.Password.IsEqualToThisHash(user.Password))
            {
                return true;
            }
            return false;
        }
    }
}
