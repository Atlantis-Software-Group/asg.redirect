using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using HContext = Microsoft.AspNetCore.Http.HttpContext;

namespace asg.redirect;

public class RedirectMiddleware
{
    private readonly RequestDelegate _next;
    private readonly RedirectOptions _options;

    public RedirectMiddleware(RequestDelegate next, IOptions<RedirectOptions> options)
    {
        _next = next;
        _options = options.Value;
    }

    public async Task InvokeAsync(HContext context)
    {
        await _next(context);
        
        if ( context.Response.StatusCode == (int)HttpStatusCode.Redirect 
                && !string.IsNullOrWhiteSpace(_options.RedirectFrom)
                && !string.IsNullOrWhiteSpace(_options.RedirectTo))
        {
            string location = context.Response.Headers["Location"];
            if ( location.StartsWith(_options.RedirectFrom) )
            {
                location = location.Replace(_options.RedirectFrom, _options.RedirectTo);
                context.Response.Redirect(location, false);
            } 
        }
    }
}
