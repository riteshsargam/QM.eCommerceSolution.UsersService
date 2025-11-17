using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")] //api/auth
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersService usersService;

    public AuthController(IUsersService usersService)
    {
        this.usersService = usersService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if (registerRequest == null)
        {
            return BadRequest("RegisterRequest object is null");
        }

       AuthenticationResponse? authenticationResponse = await usersService.Register(registerRequest);
        if (authenticationResponse == null || authenticationResponse.Success == false)
        {
            return BadRequest(authenticationResponse);
        }

        return Ok(authenticationResponse);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        if (loginRequest == null)
        {
            return BadRequest("LoginRequest object is null");
        }

        AuthenticationResponse? authenticationResponse = await usersService.Login(loginRequest);
        if (authenticationResponse == null || authenticationResponse.Success == false)
        {
            return Unauthorized(authenticationResponse);
        }

        return Ok(authenticationResponse);
    }
}