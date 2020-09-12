﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnergyAPIClient.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnergyAPIClient.Configuration
{
    public static class EnergyDBConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<EnergyDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("EnergyConnection")));
        }
    }
}
