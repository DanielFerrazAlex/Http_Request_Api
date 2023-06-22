using AutoMapper;
using CEP_HTTP_REQUEST.DTO_s;
using CEP_HTTP_REQUEST.Models;

namespace CEP_HTTP_REQUEST.Mapping
{
    public class Map : Profile
    {
        public Map()
        {
            CreateMap(typeof(ResponseHTTP<>), typeof(ResponseHTTP<>));
            CreateMap<Entity, ResponseEntity>();
        }
    }
}
