using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppNtier.Common.ResponseObjects
{
    public class Response<T>:Response,IResponse<T>
    {
      
        public Response(ResponseType responseType,T data):base(responseType)
        {
            Data=data;
        }

        public Response(ResponseType responseType,T data,List<CustomValidationError> errors):base(responseType)
        {
            Data = data;
            ValidationErrors = errors;
        }

        public Response(ResponseType responseType,string message):base(responseType,message)
        {

        }

        public T Data { get; set; }
        public List<CustomValidationError> ValidationErrors { get; set; }
    }
}
