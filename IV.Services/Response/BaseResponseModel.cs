using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV.Services.Response
{
    public class BaseResponseModel
    {
        public string? RespCode { get; set; }

        public string? RespDesc { get; set; }

        public EnumRspType RespType { get; set; }

        public bool isSuccess { get; set; }

        public bool isError { get { return !isSuccess; } }

        public static BaseResponseModel Success(string rspCode, string RspDesc)
        {
            return new BaseResponseModel()
            {
                isSuccess = true,
                RespCode = rspCode,
                RespDesc = RspDesc,
                RespType = EnumRspType.Success
            };
        }

        public static BaseResponseModel ValidationError(string rspCode, string RspDesc)
        {
            return new BaseResponseModel()
            {
                isSuccess = false,
                RespCode = rspCode,
                RespDesc = RspDesc,
                RespType = EnumRspType.ValidationError
            };
        }

        public static BaseResponseModel SystemError(string rspCode, string RspDesc)
        {
            return new BaseResponseModel()
            {
                isSuccess = false,
                RespCode = rspCode,
                RespDesc = RspDesc,
                RespType = EnumRspType.SystemError
            };
        }
    }

    public enum EnumRspType
    {
        None,
        Success,
        ValidationError,
        SystemError,
        DataNotExist
    }
}
