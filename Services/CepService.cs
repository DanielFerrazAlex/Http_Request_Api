using AutoMapper;
using CEP_HTTP_REQUEST.Data;
using CEP_HTTP_REQUEST.DTO_s;
using CEP_HTTP_REQUEST.Services.Interfaces;
using Dapper;
using MySqlConnector;

namespace CEP_HTTP_REQUEST.Services
{
    public class CepService : ICepService
    {
        private readonly IMapper _mapper;
        private readonly IExternalApiService _response;
        public CepService(IMapper mapper, IExternalApiService response)
        {
            _mapper = mapper;
            _response = response;
        }
        public async Task<ResponseHTTP<ResponseEntity>> GetCep(string cep)
        {
            var result = await _response.GetResponse(cep);
            return _mapper.Map<ResponseHTTP<ResponseEntity>>(result);
        }
        public async Task<ResponseHTTP<ResponseEntity>> InsertCepData(string cep)
        {
            var result = await _response.IsertResponse(cep);
            return _mapper.Map<ResponseHTTP<ResponseEntity>>(result);
        }
    }
}
