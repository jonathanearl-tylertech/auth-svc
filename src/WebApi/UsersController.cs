using Microsoft.AspNetCore.Mvc;
using AuthService.Application;

namespace AuthService.WebApi;

[ApiController]
[Route("[Controller]")]
public class UsersController : ControllerBase
{
    private readonly UsersService _usersService;
    public UsersController(UsersService usersService) {
        _usersService = usersService;
    }

    [HttpPost]
    public async Task<User?> CreateUser([FromBody] User user)
    {
        var result = await _usersService.Create(user);
        return result;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
        var users = await _usersService.GetAll();
        return Ok(users);
    }

    [Route("{id}")]
    [HttpGet]
    public string GetUser()
    {
        throw new NotImplementedException();
    }

    [Route("{id}")]
    [HttpPut]
    public string UpdateUser()
    {
        throw new NotImplementedException();
    }



    [Route("{id}")]
    [HttpDelete]
    public string DeleteUser()
    {
        throw new NotImplementedException();
    }
}