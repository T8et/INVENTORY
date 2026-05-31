using IV.DataCenter.Models;
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

        [HttpGet("stocktypes")]
        public IActionResult GetStockTypes()
        {
            var response = db.BtStkTypes.ToList();
            return Ok(response);
        }

        [HttpGet("GetbyId")]
        public IActionResult GetById(int id)
        {
            var response = db.BtStkTypes.Where(x=>x.StkTypeId==id).FirstOrDefault();
            if(response is null) return BadRequest();
            return Ok(response);
        }

        [HttpPost("newstktype")]
        public IActionResult CreateStkType(BtStkType dataModel)
        {
            db.BtStkTypes.Add(dataModel);
            db.SaveChanges();
            return Ok("Inserted Successfully");
        }

        [HttpPatch("PatchUpdate")]
        public IActionResult PatchUpdate(int id, BtStkType dataModel)
        {
            var list = db.BtStkTypes.Where(x => x.StkTypeId == id).FirstOrDefault();
            if (list is null)
            {
                return BadRequest();
            }

            if(dataModel.StkTypeName != null) list.StkTypeName = dataModel.StkTypeName;
            if (dataModel.StkTypeDesc != null) list.StkTypeDesc = dataModel.StkTypeDesc;
            if (dataModel.TimeLog != null) list.TimeLog = dataModel.TimeLog;
            if (dataModel.UserLog != null) list.UserLog = dataModel.UserLog;

            db.Entry(list).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(list);
        }

        [HttpPut("PutUpdate")]
        public IActionResult PutUpdate(int id,BtStkType dataModel)
        {
            var list = db.BtStkTypes.Where(x=>x.StkTypeId == id).FirstOrDefault();
            if (list is null)
            {
                return BadRequest();
            }

            list.StkTypeName = dataModel.StkTypeName;
            list.StkTypeDesc = dataModel.StkTypeDesc;
            list.TimeLog = dataModel.TimeLog;
            list.UserLog = dataModel.UserLog;

            db.Entry(list).State = EntityState.Modified;
            db.SaveChanges();
            return Ok(list);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var list = db.BtStkTypes.Where(x=>x.StkTypeId==id).FirstOrDefault();

            if(list is null)
            {
                return BadRequest();
            }

            db.Entry(list).State = EntityState.Deleted;
            db.SaveChanges();
            return Ok("Deleted Successful");
        }

    }
}
