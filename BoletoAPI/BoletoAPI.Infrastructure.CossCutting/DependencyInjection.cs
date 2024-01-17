using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BoletoAPI.Domain.Interfaces;
using BoletoAPI.Infrastructure.Data.Repositories;
using BoletoAPI.Application.Interfaces;
using BoletoAPI.Application.Services;
using BoletoNetCore;
using BoletoAPI.Application.Mappings;

namespace BoletoAPI.Infrastructure.CossCutting
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBoletoRepository, BoletoRepository>();
            //services.AddScoped<IBanco, Banco>();

            services.AddScoped<IBoletoService, BoletoService>();
            services.AddAutoMapper(typeof(DomainParaDTO));

            return services;
        }
    }
}