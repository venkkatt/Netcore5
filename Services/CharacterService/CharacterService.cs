using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using netCore5.Dtos.Character;
using netCore5.Models;
using Netcore5.Data;

namespace netCore5.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public CharacterService(IMapper mapper, DataContext dataContext)
        {
            _dataContext = dataContext;
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
            // character.Id = characters.Max(c => c.Id) + 1;
            // characters.Add(character);
            _dataContext.Characters.Add(character);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.Characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();
            var dbCharacters = await _dataContext.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            var dbCharacter = await _dataContext.Characters.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDTO>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updateCharacterDTO)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            try
            {

                Character character = await _dataContext.Characters.FirstOrDefaultAsync(c => c.Id == updateCharacterDTO.Id);

                character.Name = updateCharacterDTO.Name;
                character.Strength = updateCharacterDTO.Strength;
                character.Intelligence = updateCharacterDTO.Intelligence;
                character.Defence = updateCharacterDTO.Defence;
                character.Class = updateCharacterDTO.Class;
                character.HitPoints = updateCharacterDTO.HitPoints;

                await _dataContext.SaveChangesAsync();

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

                Character character = await _dataContext.Characters.FirstAsync(c => c.Id == id);
                _dataContext.Characters.Remove(character);
                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = await _dataContext.Characters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToListAsync();

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