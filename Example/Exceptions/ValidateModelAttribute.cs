using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace I18nWebApi.Exceptions
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var loggerFactory = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<ValidateModelAttribute>();
                var keys = context.ModelState.Keys;
                var url = context.HttpContext.Request.Path.Value;
                logger.LogWarning("url:{Url},参数{Join}验证不通过", url, string.Join(",", keys));

                var errors = context.ModelState.Values.SelectMany(s => s.Errors).Select(e => e.ErrorMessage).ToList();
                context.Result = new JsonResult(new
                {
                    code = 400,
                    msg = string.Join(";", errors)
                });
            }
        }

    }
}
