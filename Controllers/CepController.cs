using CEP_HTTP_REQUEST.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CEP_HTTP_REQUEST.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CepController : ControllerBase
    {
        private readonly ICepService _service;
        public CepController(ICepService service)
        {
            _service = service;
        }
        ///<summary>
        ///https://localhost:7025/api/v1/cep/busca/{cep}
        ///</summary>
        [HttpGet("busca/{cep}")]
        public async Task<IActionResult> GetCep([FromRoute] string cep)
        {
            var result = await _service.GetCep(cep);
            if (result.Status == HttpStatusCode.OK)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode((int)result.Status, result.Error);
            }
        }
        ///<summary>
        ///https://localhost:7025/api/v1/cep/inserir/{cep}
        ///</summary>
        [HttpPost("inserir/{cep}")]
        public async Task<IActionResult> InsertCep([FromRoute] string cep)
        {
            var result = await _service.InsertCepData(cep);
            return Ok(result);
        }
    }
}