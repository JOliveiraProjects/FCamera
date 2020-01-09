using FCamera.Application;
using FCamera.Application.Interfaces;
using FCamera.Common.Interfaces;
using FCamera.Common.Services;
using FCamera.Domain.Interfaces;
using FCamera.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FCamera.Infra.CrossCutting.Ioc
{
    public class NativeDependencyInjection
    {
        public void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BancoContext>(options =>
                options.UseNpgsql(configuration["ConnectionStrings:Database"]));

            // Services
            services.AddScoped<IPasswordHasherServices, PasswordHasherServices>();
            
            // Applications
            services.AddScoped<IAutenticaApplication, AutenticaApplication>();
            services.AddScoped<ITokenApplication, TokenApplication>();

            // Repositories
            services.AddScoped<IAutenticaRepository, AutenticaRepository>();
        }
    }
}
