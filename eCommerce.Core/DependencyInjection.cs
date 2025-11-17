using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core;
public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<IUsersService, UsersService>();

        return services;
    }
}

