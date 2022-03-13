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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.User?.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<bool> UsernameExists(string username)
        {
            return await Task.FromResult(_context.User.Any(u => u.Username == username));
        }

        public async Task<User> ValidateUserAsync(User inputUser)
        {
            var validUser = await _context.User.Where(u => u.Username.Equals(inputUser.Username)
                                                        && u.Password.Equals(inputUser.Password)).FirstOrDefaultAsync();

            return validUser ?? inputUser;

        }
    }
}
