using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModalCRUD.Core.Data.Repositories;
using ModalCRUD.Core.Services;
using ModalCRUD.Infrastructure.Data.Contexts;
using ModalCRUD.Infrastructure.Data.Repositories;
using ModalCRUD.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalCRUD.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConStr"))
            );

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // Services
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
