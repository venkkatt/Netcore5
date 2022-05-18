using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using netCore5.Dtos.Character;
using netCore5.Models;

namespace netCore5.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;

        }
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character { Id=1, Name ="sam" }
        };
        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            serviceResponse.Data = _mapper.Map<GetCharacterDTO>(characters.FirstOrDefault(c => c.Id == id));
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updateCharacterDTO)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            try
            {

                Character character = characters.First(c => c.Id == updateCharacterDTO.Id);

                character.Name = updateCharacterDTO.Name;
                character.Strength = updateCharacterDTO.Strength;
                character.Intelligence = updateCharacterDTO.Intelligence;
                character.Defence = updateCharacterDTO.Defence;
                character.Class = updateCharacterDTO.Class;
                character.HitPoints = updateCharacterDTO.HitPoints;

                serviceResponse.Data = _mapper.Map<GetCharacterDTO>(character);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.StackTrace;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            try
            {

                Character character = characters.First(c => c.Id == id);
                characters.Remove(character);
                serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.StackTrace;
            }
            return serviceResponse;
        }
    }
}