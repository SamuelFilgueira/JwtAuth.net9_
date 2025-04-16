using JwtAuthDotNet.Entities;
using JwtAuthDotNet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDotNet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("add-user", Name ="add-user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult AddUser(User user)
    {
        _userService.Add(user);
        return Ok("User inserted successfully");
    }
}
