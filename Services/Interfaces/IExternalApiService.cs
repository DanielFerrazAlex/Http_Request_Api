using CEP_HTTP_REQUEST.DTO_s;
using CEP_HTTP_REQUEST.Models;

namespace CEP_HTTP_REQUEST.Services.Interfaces
{
    public interface IExternalApiService
    {
        Task<ResponseHTTP<Entity>> GetResponse(string cep);
        Task<bool> IsertResponse(string cep);
    }
}
