namespace I18nWebApi.Exceptions
{
    public interface IHandlingMiddleware
    {
        Task InvokeAsync(HttpContext httpContext);
    }
}
