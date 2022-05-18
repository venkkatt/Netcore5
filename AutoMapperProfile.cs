using AutoMapper;
using netCore5.Dtos.Character;
using netCore5.Models;

namespace netCore5
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