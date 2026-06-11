using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV.MyClient.ClientServices
{
    public interface StkTypeApi
    {
        [Get("/api/StkType/stocktypes")]
        Task<List<StkType>> GetStockTypes();

        [Get("/api/StkType/GetbyId")]
        Task<List<StkType>> GetById(int id);
    }

    public class StkType
    {
        public int StkTypeId { get; set; }

        public string? StkTypeName { get; set; }

        public string? StkTypeDesc { get; set; }

        public DateTime? TimeLog { get; set; }

        public string? UserLog { get; set; }
    }
}
