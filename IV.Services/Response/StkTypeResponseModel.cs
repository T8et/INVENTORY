using IV.DataCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV.Services.Response
{
    public class StkTypeResponseModel
    {
        public BaseResponseModel? response { get; set; }

        public BtStkType? cmresponse { get; set; }
    }
}
