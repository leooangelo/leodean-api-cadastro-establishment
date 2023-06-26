using Microsoft.AspNetCore.Builder;
using MS.Establishment.Domain.Middlewares;

namespace MS.Establishment.Domain.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
