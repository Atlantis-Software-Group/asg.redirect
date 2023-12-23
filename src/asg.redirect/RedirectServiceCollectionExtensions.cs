using Microsoft.Extensions.DependencyInjection;

namespace asg.redirect;

public static class RedirectServiceCollectionExtensions
{
    public static IServiceCollection AddRedirect(this IServiceCollection services, Action<RedirectOptions> configureOptions)
    {
        services.Configure(configureOptions);
        return services;
    }        
}
