using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IV.Services.Response
{
    public class CmResponseModel<T>
    {
        public string? RespCode { get; set; }

        public string? RespDesc { get; set; }
        public T? Data { get; set; }

        public string? Message { get; set; }

        public EnumResType RespType { get; set; }

        public bool isSuccess { get; set; }

        public bool isError { get { return !isSuccess; } }

        public bool isValidationErr { get { return RespType == EnumResType.ValidationError; } }

        public bool isSystemErr { get { return RespType == EnumResType.SystemError; } }

        public bool isDataIssue { get { return RespType == EnumResType.DataNotExist; } }

        public static CmResponseModel<T> Success(T data, string message)
        {
            return new CmResponseModel<T>()
            {
                isSuccess = true,
                Data = data,
                Message = message,
                RespType = EnumResType.Success
            };
        }

        public static CmResponseModel<T> ValidationError(string message, T? data = default)
        {
            return new CmResponseModel<T>()
            {
                isSuccess = false,
                Data = data,
                Message = message,
                RespType = EnumResType.ValidationError
            };
        }

        public static CmResponseModel<T> SystemError(string message, T? data = default)
        {
            return new CmResponseModel<T>()
            {
                isSuccess = false,
                Data = data,
                Message = message,
                RespType = EnumResType.SystemError
            };
        }

        public static CmResponseModel<T> DataNotExist(string message, T? data = default)
        {
            return new CmResponseModel<T>()
            {
                isSuccess = false,
                Data = data,
                Message = message,
                RespType = EnumResType.DataNotExist
            };
        }
    }
}

public enum EnumResType
{
    None,
    Success,
    ValidationError,
    SystemError,
    DataNotExist
}
