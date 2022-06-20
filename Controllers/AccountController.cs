using ApiAuth.Models;
using ApiAuth.Repositories;
using ApiAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    // private readonly TokenService _tokenService;

    // public AccountController(TokenService tokenService)
    // {
    //     _tokenService = tokenService;
    // }

    [HttpPost]
    [Route("v1/login")]
    public async Task<ActionResult<dynamic>> AuthenticateAsync(
        [FromServices] TokenService tokenService,
        User modelRequest)
    {
        var user = UserRepository.Get(modelRequest.Username, modelRequest.Password);

        if(user is null)
            return BadRequest(new { message = "User not found!" });

        var token = tokenService.GenerateToken(user);

        user.Password = string.Empty;

        return new 
        {
            user = user,
            token = token
        };
    }
}
