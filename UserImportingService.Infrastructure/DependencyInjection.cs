using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserImportingService.Application.Common.Interfaces;
using UserImportingService.Infrastructure.CSV;
using UserImportingService.Infrastructure.CSV.Mappers;
using UserImportingService.Infrastructure.JSON;
using UserImportingService.Infrastructure.Persistence;

namespace UserImportingService.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(ICSVParser), typeof(StudentCSVParser));
            services.AddTransient(typeof(IJSONWriter), typeof(JSONWriter));
            services.AddTransient(typeof(IMapperProvider), typeof(MapperProvider));
            services.AddTransient(typeof(IStudentRepository), typeof(StudentRepository));
        }
    }
}
