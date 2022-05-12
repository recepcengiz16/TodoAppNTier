using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoAppNTier.Business.Interfaces;
using TodoAppNTier.Business.Services;
using TodoAppNTier.Business.ValidationRules;
using TodoAppNTier.DataAccess.Contexts;
using TodoAppNTier.DataAccess.UnitOfWorks;
using TodoAppNTier.DTO.WorkDTOs;

namespace TodoAppNTier.Business.DependencyResolvers
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("TodoDB"));
            });

            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IWorkService, WorkService>();

            services.AddTransient<IValidator<WorkCreateDTO>, WorkCreateDTOValidator>();
            services.AddTransient<IValidator<WorkUpdateDTO>, WorkUpdateDTOValidator>();
        }
    }
}
