using Microsoft.EntityFrameworkCore;
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

        public async Task<User> SignUp(User user)
        {
            if (await UsernameExists(user.Username)) { return null!; }

            return await _userRepository.CreateAsync(user);
        }

        public async Task<bool> UsernameExists(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username);

            return await Task.FromResult(user != null);
        }

        public async Task<bool> ValidateUser(User inputUser)
        {
            var user = await _userRepository.GetByUsernameAsync(inputUser.Username); // User from Db

            if (user == null) { return false; }

            var userHasValidCredentials = inputUser.Username.Equals(user.Username) &&
                                          inputUser.Password.IsEqualToThisHash(user.Password);

            if (userHasValidCredentials) { return true; }

            return false;
        }
    }
}
