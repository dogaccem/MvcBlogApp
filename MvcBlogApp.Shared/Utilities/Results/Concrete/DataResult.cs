using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcBlogApp.Shared.Utilities.Results.Abstract;
using MvcBlogApp.Shared.Utilities.Results.ComplexTypes;

namespace MvcBlogApp.Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
        public T Data { get; }

        public DataResult(ResultStatus resultStatus,T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message,T data)
        {
            ResultStatus = resultStatus;
            Message = message;
            Data = data;
        }
        public DataResult(ResultStatus resultStatus, string message, Exception exception, T data)
        {
            ResultStatus = resultStatus;
            Message = message;
            Exception = exception;
            Data = data;
        }
    }
}
