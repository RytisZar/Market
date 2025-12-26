using Microsoft.AspNetCore.Mvc;
using market.Services;

namespace market.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    // Constructor injection (DI happens here)
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet ("list")]
    public IActionResult GetList()
    {
        var result = _userService.GetUsers();
        return Ok(result);
    }

    [HttpGet ("{id}")]
    public IActionResult Get(int id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Add([FromQuery] string name = "world")
    {
        var result = _userService.Add(name);
        return Ok(result);
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
        return NoContent();
    }


}
