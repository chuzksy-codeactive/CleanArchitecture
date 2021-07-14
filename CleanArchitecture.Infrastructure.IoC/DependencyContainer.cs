using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CleanArchitecture.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application Layer
            services.AddScoped<ICourseService, CourseService>();

            // Infrastructure.Data Layer
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
