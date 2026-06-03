using IV.Services.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IV.ApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        [HttpGet("Response")]
        public IActionResult Execute(object rspobj)
        {
            JObject newObj = JObject.Parse(JsonConvert.SerializeObject(rspobj));

            if(newObj is not null)
            {
                BaseResponseModel model = JsonConvert.DeserializeObject<BaseResponseModel>(newObj["response"]!.ToString())!;

                if(model.RespType == EnumRspType.ValidationError)
                {
                    return BadRequest(model);
                }

                if (model.RespType == EnumRspType.SystemError)
                {
                    return BadRequest(model);
                }

                if (model.RespType == EnumRspType.Success)
                {
                    return Ok(model);
                }
            }

            return StatusCode(503, "Invalid Response Model");
        }
    }
}
