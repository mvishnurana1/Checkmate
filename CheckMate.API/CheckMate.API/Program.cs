using Checkmate.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<CheckMateDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CheckMateDBConnectionString"));
});

//builder.Services.AddCors(options =>
//{
//         options.AddDefaultPolicy(
//            builder =>
//            {
//                builder.WithOrigins("https://localhost:44351", "http://localhost:4200")
//                            .AllowAnyHeader()
//                            .AllowAnyMethod();
//            }
//         );
//});

builder.Services.AddCors();
builder.Configuration
       .AddEnvironmentVariables();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(options =>
{
    var clientID = builder.Configuration["Authentication:Google:ClientId"];
    var secret = builder.Configuration["Authentication:Google:ClientSecret"];

    options.ClientId = clientID!;
    options.ClientSecret = secret!;
    options.Scope.Add("profile");
    options.Scope.Add("email");
    options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "sub");
    options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
    options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
