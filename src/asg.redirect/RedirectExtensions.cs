using Microsoft.AspNetCore.Builder;

namespace asg.redirect;

public static class RedirectExtensions
{
    public static IApplicationBuilder UseIdpRedirect(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        return app.UseMiddleware<RedirectMiddleware>();
    }

}
