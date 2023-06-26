using CEP_HTTP_REQUEST.DTO_s;

namespace CEP_HTTP_REQUEST.Services.Interfaces
{
    public interface ICepService
    {
        Task<ResponseHTTP<ResponseEntity>> GetCep(string cep);
        Task<bool> InsertCepData(string cep);
    }
}
