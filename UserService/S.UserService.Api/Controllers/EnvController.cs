using Microsoft.AspNetCore.Mvc;

namespace S.UserService.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class EnvController : ControllerBase
{
    private readonly IConfiguration configuration;

    public EnvController(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    [HttpGet]
    public IActionResult EnvironmentVariables()
    {
        return Ok(new
        {
            SettingServiceBaseUrl = configuration["settingServiceBaseUrl"]
        });
    }
}