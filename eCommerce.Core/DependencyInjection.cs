using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core;
public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        return services;
    }
}

