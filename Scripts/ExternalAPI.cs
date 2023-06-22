using CEP_HTTP_REQUEST.DTO_s;
using CEP_HTTP_REQUEST.Models;
using CEP_HTTP_REQUEST.Services.Interfaces;
using System.Dynamic;
using System.Text.Json;

namespace CEP_HTTP_REQUEST.Scripts
{
    public class ExternalAPI : IExternalApiService
    {
        public async Task<ResponseHTTP<Entity>> GetResponse(string cep)
        {
            var Request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");
            var Response = new ResponseHTTP<Entity>();

            using( var Client = new HttpClient() )
            {
                var ResponseExternal = await Client.SendAsync(Request);
                var ContentExternal = await ResponseExternal.Content.ReadAsStringAsync();
                var ObjectResult = JsonSerializer.Deserialize<Entity>(ContentExternal);

                if(ResponseExternal.IsSuccessStatusCode)
                {
                    Response.Status = ResponseExternal.StatusCode;
                    Response.Data = ObjectResult;
                }
                else
                {
                    Response.Status = ResponseExternal.StatusCode;
                    Response.Error = JsonSerializer.Deserialize<ExpandoObject>(ContentExternal);
                }
            }
            return Response;
        }
    }
}
