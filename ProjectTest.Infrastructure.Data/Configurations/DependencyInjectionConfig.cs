﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectTest.Infrastructure.Data.Context;
using ProjectTest.Domain.Interfaces.Common;
using ProjectTest.Infrastructure.Data.Repositories.Common;
using ProjectTest.Application.Interfaces;
using ProjectTest.Application.Services;
using ProjectTest.Domain.Interfaces.Repository;
using ProjectTest.Infrastructure.Data.Repositories;
using ProjectTest.Domain.Entities;
using ProjectTest.Domain.Interfaces;

namespace ProjectTest.Infrastructure.Data.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationRoot configuration)
        {
            AddDataBase(services, configuration);
            AddRepositories(services);
            AddStoreProcedures(services);
            return services;
        }

        private static void AddDataBase(IServiceCollection services, IConfigurationRoot configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<ProjectTestContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();
            }, ServiceLifetime.Scoped);
        }

        public static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddTransient(typeof(IGenericAsyncRepository<>), typeof(GenericAsyncRepository<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAcessoUsuarioRepository, AcessoUsuarioRepository>();
            services.AddScoped<ICurrentUserInfo, CurrentUserInfo>();
            services.AddScoped<IPedidoRepository, PedidoRepository>(); 
            services.AddScoped<IEnderecoEntregaRepository, EnderecoEntregaRepository>();

        }

        public static void AddStoreProcedures(IServiceCollection services)
        {

        }
    }
}
