using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[Controller]")]
public class UsersController : ControllerBase {
    public UsersController() {}

    [HttpGet]
    public string GetUsers() {
        return "users!";
    }
}