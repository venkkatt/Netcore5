using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netCore5.Dtos.Character;
using netCore5.Models;
using netCore5.Services.CharacterService;

namespace netCore5.Controllers
{
    //post - create
    //Get - Read
    //Put - Update
    //Delete - Delete

    //Models are bind to the Database objects and it will have so much of information in it. We don't need to expose to the user. 
    //In This case we create a Data transfer
    //object with only required field and send the result to the user.- Automapper do this for us. 
    //Also we can create DTO with combining multiple models and send data to the user.

    //As a Best practise we should not define any logic in the controller class.Instead it should be in service class.
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDTO>>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> UpdateCharacter(UpdateCharacterDTO updateCharacterDTO)
        {
            var response = await _characterService.UpdateCharacter(updateCharacterDTO);
            return response.Success ? Ok(response) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDTO>>> DeleteCharacter(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            return response.Success ? Ok(response) : NotFound();
        }


    }
}