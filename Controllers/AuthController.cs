using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netCore5.Models;
using Netcore5.Data;
using Netcore5.Dtos.User;

namespace Netcore5.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;

        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepository.Register(
                  new Models.User { UserName = request.UserName }, request.PassWord
              );
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
        {
            var response = await _authRepository.Login(request.UserName, request.Password);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
