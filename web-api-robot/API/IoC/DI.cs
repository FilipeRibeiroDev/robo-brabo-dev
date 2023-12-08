using Application.Services;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Infraestructure;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.IoC
{
    public static class DI
    {
        public static void AddSdk(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddDbContext<BraboDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
