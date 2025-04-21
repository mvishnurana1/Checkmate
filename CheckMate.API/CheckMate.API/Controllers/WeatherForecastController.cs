using CheckMate.API.Auth;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;

namespace CheckMate.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IConfiguration configuration, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _configuration = configuration;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("/login")]
        public IActionResult Login()
        {
            var redirectUrl = Url.Action("GoogleResponse", "WeatherForecast");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("GoogleResponse")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync();
            var email = result.Principal!.FindFirst(ClaimTypes.Email)?.Value!;
            var name = result.Principal!.FindFirst(ClaimTypes.Name)?.Value!;
            var gender = result.Principal!.FindFirst(ClaimTypes.Gender)?.Value!;


            string issuer = _configuration["Jwt:Issuer"]!;
            string audience = _configuration["Jwt:Audience"]!;
            string secret = _configuration["Jwt:Secret"]!;

            var token = JwtHelper.CreateToken(email, name, gender, issuer, audience, secret);

            _logger.Log(LogLevel.Information, token);

            // Redirect back to Angular with token
            return Redirect($"http://localhost:4200/auth-callback?token={token}");
        }
    }
}
