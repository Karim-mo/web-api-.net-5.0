using AutoMapper;
using web_api_course_.net_5._0.DTOs.Character;
using web_api_course_.net_5._0.Models;

namespace web_api_course_.net_5._0
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
        }
    }
}