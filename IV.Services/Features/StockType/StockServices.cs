using IV.DataCenter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV.Services.Features.StockType
{
    public class StockServices
    {
        private readonly AppDBContext _db = new AppDBContext();

        public List<BtStkType> GetAllStkTypes()
        {
            var response = _db.BtStkTypes.AsNoTracking().ToList();
            return response;
        }

        public List<BtStkType> GetStkTypeById(int id)
        {
            var response = _db.BtStkTypes.AsNoTracking().Where(x => x.StkTypeId == id).ToList();
            return response;
        }

        public BtStkType PostStkType(BtStkType dataModel)
        {
            _db.BtStkTypes.Add(dataModel);
            _db.SaveChanges();
            return dataModel;
        }

        public BtStkType PutStkType(int id,BtStkType dataModel)
        {
            var response = _db.BtStkTypes.AsNoTracking().Where(x => x.StkTypeId == id).FirstOrDefault();

            if(response == null) return null!;

            response.StkTypeName = dataModel.StkTypeName;
            response.StkTypeDesc = dataModel.StkTypeDesc;
            response.UserLog = dataModel.UserLog;
            response.TimeLog = dataModel.TimeLog;

            _db.Entry(response).State = EntityState.Modified;
            _db.SaveChanges();

            return dataModel;
        }

        public BtStkType PatchStkType(int id, BtStkType dataModel)
        {
            var response = _db.BtStkTypes.AsNoTracking().Where(x => x.StkTypeId == id).FirstOrDefault();

            if (response == null) return null!;

            if(dataModel.StkTypeName is not null) response.StkTypeName = dataModel.StkTypeName;
            if (dataModel.StkTypeDesc is not null) response.StkTypeDesc = dataModel.StkTypeDesc;
            if (dataModel.UserLog is not null) response.UserLog = dataModel.UserLog;
            if (dataModel.TimeLog is not null) response.TimeLog = dataModel.TimeLog;

            _db.Entry(response).State = EntityState.Modified;
            _db.SaveChanges();

            return dataModel;
        }

        public string DeleteStkType(int id)
        {
            var response = _db.BtStkTypes.AsNoTracking().Where(x=>x.StkTypeId == id).FirstOrDefault();

            if (response == null) return "";

            _db.Entry(response!).State = EntityState.Deleted;
            _db.SaveChanges();

            return "Deleted Successfully";
        }
    }
}
