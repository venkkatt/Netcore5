using System.Collections.Generic;
using System.Threading.Tasks;
using netCore5.Dtos.Character;
using netCore5.Models;

namespace netCore5.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter);
        Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updateCharacterDTO);
        Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int id);

    }
}