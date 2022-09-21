using Ecommerces_MS.Models;
using Ecommerces_MS.Repository;
using Ecommerces_MS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Ecommerces_MS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly UserdbContext _dbContext;
        private readonly IRepo _repo;

        public AuthController(IConfiguration configuration , IUserService userService, UserdbContext db , IRepo r)
        {
            _configuration = configuration;
            _userService = userService;
            _dbContext = db;
            _repo = r;
        }

        [HttpPost]
        [Route("register")]

        public IActionResult Signup([FromBody] UserRegister reg)
        {
            _dbContext.BuildConnectionString(_configuration.GetConnectionString("registerConn"));
            var status = _repo.createCustomers(reg);

            if (status == "OK")
            {
                return Ok(new { message = "customer created successfully!" });
            }
            else
            {
                return StatusCode(429, status);
            }
        }


    }
}


/*[HttpGet , Authorize]

        public ActionResult<string> GetMe()
        {
            var Username = _userService.GetUserName();
            
            return Ok(Username);
        }

        [HttpPost("register")]

        public async Task<ActionResult<User>>Register(UserRegister request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

             return Ok(user);

        }


        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserRegister request) {

            if (user.Username != request.Username)
            {
                return BadRequest("user not found");
            }
            
   string token = CreateToken(user);
            return Ok(token);
}

        private string CreateToken(User user)
{
    List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name , user.Username)
            };

    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

    var token = new JwtSecurityToken(
        claims: claims,
        expires: DateTime.Now.AddMinutes(1),
        signingCredentials: creds
        );

    var jwt = new JwtSecurityTokenHandler().WriteToken(token);

    return jwt;
}
private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
{
    using (var hmac = new HMACSHA512())
    {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
    }
}*/