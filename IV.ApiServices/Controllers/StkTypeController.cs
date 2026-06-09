using IV.DataCenter.Models;
using IV.Services.Features.StockType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IV.ApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StkTypeController : ResponseController
    {
        private readonly StkTypeServices service;

        public StkTypeController(StkTypeServices _service)
        {
            service = _service;
        }

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
        public async Task<IActionResult> CreateStkType(BtStkType dataModel)
        {
            var response = await service.PostStkType(dataModel);
            return Execute(response);
        }

        [HttpPost("newstktype1")]
        public async Task<IActionResult> CreateStkType1(BtStkType dataModel)
        {
            var response = await service.PostStkType1(dataModel);
            return Execute1(response);
        }

        [HttpPatch("PatchUpdate")]
        public async Task<IActionResult> PatchUpdate(int id, BtStkType dataModel)
        {
            var response = await service.PatchStkType(id, dataModel);
            return Execute(response);
        }

        [HttpPut("PutUpdate")]
        public async Task<IActionResult> PutUpdate(int id,BtStkType dataModel)
        {
            var response = await service.PutStkType(id, dataModel);
            return Execute(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await service.DeleteStkType(id);
            return Execute(response);
        }
    }
}
