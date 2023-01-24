using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.JwpApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.JwpApp.Persistence
{
    public static  class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<JwtContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });
        }
    }
}
