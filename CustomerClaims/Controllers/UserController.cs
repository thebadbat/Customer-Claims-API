using CustomerClaims.Interfaces;
using CustomerClaims.Models;
using CustomerClaims.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerClaims.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly JwtService _jwtService;

    public UserController(IUserService userService, JwtService jwtService)
    {
        _userService = userService;
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login(UserModel model)
    {
        if (!_userService.ValidateUserCredentialsAsync(model.Username, model.Password).Result)
            return Unauthorized();

        var token = _jwtService.GenerateJwtToken(model.Username);
        return Ok(new { Token = token });
    }
}
