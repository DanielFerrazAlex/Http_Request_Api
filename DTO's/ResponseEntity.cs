using System.Text.Json.Serialization;

namespace CEP_HTTP_REQUEST.DTO_s
{
    public class ResponseEntity
    {
        public string? CEP { get; set; }
        public string? Estado { get; set; }
        public string? Cidade { get; set; }
        public string? Bairro { get; set; }
        public string? Rua { get; set; }
        [JsonIgnore]
        public string? Servico { get; set; }
    }
}
