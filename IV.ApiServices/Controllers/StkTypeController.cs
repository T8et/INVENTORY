using IV.DataCenter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IV.ApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StkTypeController : ControllerBase
    {
        private readonly AppDBContext db = new AppDBContext();

        [HttpGet("stocktypes")]
        public IActionResult GetStockTypes()
        {
            var response = db.BtStkTypes.ToList();
            return Ok(response);
        }
    }
}
