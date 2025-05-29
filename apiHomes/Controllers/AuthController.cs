using apiHomes.Helpers;
using apiHomes.Models;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiHomes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private  readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public AuthController(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] Login request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest("Credenciais inválidas.");
            var user = await _context.User.FirstOrDefaultAsync(u =>
            u.Email == request.Email && u.Password == request.Password);

            if (user == null)
                return Unauthorized("Email ou senha incorretos.");

            var token = _jwtService.GenerateToken(user);

            return Ok(new LoginResponse
            {
                Token = token,
                User = new UserDTO
                {
                    Name = user.Name,
                    Email = user.Email,
                    Status = user.Status,
                    Role = user.Role,
                    Phone = user.Phone,
                    Location = user.Location
                }
            });
        }

    }
}
