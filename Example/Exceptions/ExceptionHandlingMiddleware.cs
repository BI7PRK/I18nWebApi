using Newtonsoft.Json;
using System.Net;

namespace I18nWebApi.Exceptions
{
    public class ExceptionHandlingMiddleware(RequestDelegate next) : IHandlingMiddleware
    {

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                code = context.Response.StatusCode,
                msg = exception.Message
            }));
        }


    }
    public static class ExceptionHandlingExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }

}
