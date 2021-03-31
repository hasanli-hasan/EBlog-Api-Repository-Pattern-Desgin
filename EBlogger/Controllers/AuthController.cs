using EBlogger.Models;
using EBlogger.ToDoItems;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EBlogger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration Configuration;
        public AuthController(UserManager<AppUser> userManager, IConfiguration config, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            Configuration = config;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            AppUser IsExistUsername = await _userManager.FindByNameAsync(register.Username);

            if(IsExistUsername != null)
            {
                return BadRequest(new { message = "This Username alredy exist !" });
            }

            AppUser IsExistEmail = await _userManager.FindByEmailAsync(register.Email);

            if (IsExistEmail != null)
            {
                return BadRequest(new { message = "This Email alredy exist !" });
            }

            AppUser newUser = new AppUser
            {
                Email = register.Email,
                UserName=register.Username
            };

          IdentityResult result=  await _userManager.CreateAsync(newUser, register.Password);
          if (!result.Succeeded) return BadRequest();

            await _userManager.AddToRoleAsync(newUser, "User");
            return Ok(new { message = "Successfuly Registered !" });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
           AppUser user= await _userManager.FindByNameAsync(login.Username);
            if (user !=null && await _userManager.CheckPasswordAsync(user,login.Password))
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                var userRoles =await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role,role));
                }

                var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: Configuration["JWT:ValidIssuer"],
                    audience: Configuration["JWT:ValidAudience"],
                    expires:DateTime.Now.AddDays(1),
                    claims: authClaims,
                    signingCredentials:new SigningCredentials(signInKey,SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new {
                    token=new JwtSecurityTokenHandler().WriteToken(token),
                    expirationTime= token.ValidTo
                });
            };

            return Unauthorized(new { message="Login or Password Incorrect"});
        }

        //[HttpPost]
        //[Route("create-role")]
        //public async Task CreateRole()
        //{
        //    if( !await _roleManager.RoleExistsAsync("Admin"))
        //   await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    if (!await _roleManager.RoleExistsAsync("User"))
        //        await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
        //}
    }
}
