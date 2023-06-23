using CEP_HTTP_REQUEST.DTO_s;
using CEP_HTTP_REQUEST.Models;
using CEP_HTTP_REQUEST.Services.Interfaces;
using System.Dynamic;
using System.Text.Json;
using CEP_HTTP_REQUEST.Data;
using Dapper;
using Newtonsoft.Json;

namespace CEP_HTTP_REQUEST.Scripts
{
    public class ExternalAPI : IExternalApiService
    {
        private readonly Context _context;
        public ExternalAPI(Context context)
        {
            _context = context;
        }
        public async Task<ResponseHTTP<Entity>> GetResponse(string cep)
        {
            var Request = new HttpRequestMessage(HttpMethod.Get, $"https://brasilapi.com.br/api/cep/v1/{cep}");
            var Response = new ResponseHTTP<Entity>();
            using (var Client = new HttpClient())
            {
                var ResponseExternal = await Client.SendAsync(Request);
                var ContentExternal = await ResponseExternal.Content.ReadAsStringAsync();
                var ObjectResult = JsonConvert.DeserializeObject<Entity>(ContentExternal);

                if (ResponseExternal.IsSuccessStatusCode)
                {
                    Response.Status = ResponseExternal.StatusCode;
                    Response.Data = ObjectResult;
                }
                else
                {
                    Response.Status = ResponseExternal.StatusCode;
                    Response.Error = JsonConvert.DeserializeObject<ExpandoObject>(ContentExternal);
                }
            }
            return Response;
        }
        public async Task<ResponseHTTP<Entity>> IsertResponse(string cep)
        {
            string url = $"https://brasilapi.com.br/api/cep/v1/{cep}";
            var Res = new ResponseHTTP<Entity>();
            List<Entity> values;
            using (var Client = new HttpClient())
            {
                HttpResponseMessage Response = Client.GetAsync(url).Result;
                if(Response.IsSuccessStatusCode)
                {
                    var Content = await Response.Content.ReadAsStringAsync();
                    values = (List<Entity>)JsonConvert.DeserializeObject(Content);
                    using (var conn = _context.CreateConnection())
                    {
                        conn.Open();
                        foreach (var item in values)
                        {
                            var query = @"INSERT INTO bankcep (cep, estado, cidade, bairro, rua, servico) 
                                VALUES (@cep, @estado, @cidade, @bairro, @rua, @servico)";
                            await conn.ExecuteAsync(query, item);
                        }
                    }
                }
            }
            return Res;
        }
    }
}
