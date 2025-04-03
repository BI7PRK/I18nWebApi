using AspNetCore.Grpc.LocalizerStore.Service;
using I18nWebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace I18nWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ILogger<CulturesController> logger, IStringLocalizerStore stringLocalizer) : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(UserLoginDtos data)
        {
            if (!data.Username.Equals("admin"))
            {
                return new JsonResult(new
                {
                    Success = false,
                    msg = stringLocalizer.GetString("user_login")
                });
            }
            return new JsonResult(new
            {
                Success = true,
                data
            });
        }
    }
}
