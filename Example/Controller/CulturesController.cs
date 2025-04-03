using AspNetCore.Grpc.LocalizerStore.Service;
using GoI18n;
using I18nWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace I18nWebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CulturesController(ICultureLocalizerService localizerService, IStringLocalizerStore localizerStore, ILogger<CulturesController> logger) : ControllerBase
    {
        [HttpGet("GetCulture")]
        public async Task<IActionResult> GetCulture()
        {
            var res = await localizerService.GetCultureListAsync();
            return new JsonResult(new
            {
                code = res.Code == ReplyCode.Success ? 0 : (int)res.Code,
                msg = res.Message,
                data = res.Items
            });

        }
        [HttpGet("GetLangs")]
        public IActionResult GetLangs(string code = "zh-CN")
        {
            var res = localizerStore.GetAllStrings();
            return new JsonResult(new
            {
                code = 0,
                msg = "ok",
                data = res
            });
        }

        [HttpPost("EditCulture")]
        public async Task<IActionResult> EditCulture(CulturesDtos cultures)
        {
            var res = await localizerService.EditCultureAsync(new CultureItem
            {
                Id = cultures.Id,
                Name = cultures.Name,
                Code = cultures.Code,
                IsDefault = cultures.IsDefault
            });
            return new JsonResult(new
            {
                code = res.Code == ReplyCode.Success ? 0 : (int)res.Code,
                msg = res.Message
            });

        }


        [HttpPost("EditCultureKey")]
        public async Task<IActionResult> EditCultureKey(CulturesKeyDtos cultures)
        {
            var res = await localizerService.EditResourceKeyAsync(new CultureKeyItem
            {
                Id = cultures.Id,
                Name = cultures.Key,
                TypeId = cultures.TypeId
            });
            return new JsonResult(new
            {
                code = res.Code == ReplyCode.Success ? 0 : (int)res.Code,
                msg = res.Message
            });

        }

        [HttpPost("EditCultureLangs")]
        public async Task<IActionResult> EditCultureLangs()
        {
            var res = await localizerService.AddResourceKeyValueAsync("user_login", new CultureKeyValue[] {
                        new CultureKeyValue{ CultureId = 1, Text = "用户登陆" },
                              new CultureKeyValue{ CultureId = 2, Text = "用户登陆FF" },
                              new CultureKeyValue{ CultureId = 3, Text = "user login" },
                               new CultureKeyValue{ CultureId = 4, Text = "เข้าสู่ระบบ" },
                       });
            return new JsonResult(new
            {
                code = res.Code == ReplyCode.Success ? 0 : (int)res.Code,
                msg = res.Message
            });

        }
    }
}
