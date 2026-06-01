using IV.DataCenter.Models;
using IV.Services.Features.StockType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IV.ApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StkTypeController : ControllerBase
    {
        private readonly AppDBContext db = new AppDBContext();

        private readonly StockServices service = new StockServices();

        [HttpGet("stocktypes")]
        public IActionResult GetStockTypes()
        {
            var response = service.GetAllStkTypes();
            return Ok(response);
        }

        [HttpGet("GetbyId")]
        public IActionResult GetById(int id)
        {
            var response = service.GetStkTypeById(id);
            if(response is null) return BadRequest();
            return Ok(response);
        }

        [HttpPost("newstktype")]
        public IActionResult CreateStkType(BtStkType dataModel)
        {
            var response = service.PostStkType(dataModel);
            if (response is null) return BadRequest();
            return Ok(response);
        }

        [HttpPatch("PatchUpdate")]
        public IActionResult PatchUpdate(int id, BtStkType dataModel)
        {
            var response = service.PatchStkType(id, dataModel);
            if (response == null) return BadRequest();
            return Ok(response);
        }

        [HttpPut("PutUpdate")]
        public IActionResult PutUpdate(int id,BtStkType dataModel)
        {
            var response = service.PutStkType(id, dataModel);
            if (response == null) return BadRequest();
            return Ok(response);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var response = service.DeleteStkType(id);
            if(response == null) return BadRequest();
            return Ok(response);
        }
    }
}
