﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BD;
using WBL;
namespace WebAppLab
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {

            services.AddSingleton<IDataAccess,DataAccess>();

            services.AddTransient<IMarcaVehiculoService, MarcaVehiculoService>();
            services.AddTransient<IVehiculoService, VehiculoService>();

            return services;
        }
    }
}
