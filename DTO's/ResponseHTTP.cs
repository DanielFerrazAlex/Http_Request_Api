using System.Dynamic;
using System.Net;

namespace CEP_HTTP_REQUEST.DTO_s
{
    public class ResponseHTTP<T> where T : class
    {
        public HttpStatusCode Status { get; set; }
        public T? Data { get; set; }
        public ExpandoObject? Error { get; set; }
    }
}
