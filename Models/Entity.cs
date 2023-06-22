﻿using System.Text.Json.Serialization;

namespace CEP_HTTP_REQUEST.Models
{
    public class Entity
    {
        [JsonPropertyName("cep")]
        public string? CEP { get; set; }

        [JsonPropertyName("state")]
        public string? Estado { get; set; }

        [JsonPropertyName("city")]
        public string? Cidade { get; set; }

        [JsonPropertyName("neighborhood")]
        public string? Bairro { get; set; }

        [JsonPropertyName("street")]
        public string? Rua { get; set; }

        [JsonPropertyName("service")]
        public string? Servico { get; set; }
    }
}