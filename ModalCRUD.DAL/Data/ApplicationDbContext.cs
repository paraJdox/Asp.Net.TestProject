using Microsoft.EntityFrameworkCore;
using ModalCRUD.Models;

namespace ModalCRUD.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // This is an empty constructor, but the parameter is needed for dependency injection
        }

        public DbSet<Employee> Employee { get; set; } = null!;
        public DbSet<User> User { get; set; } = null!;
    }
}
