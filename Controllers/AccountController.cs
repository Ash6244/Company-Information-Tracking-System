using CompanyInfoTrackingSystem.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CompanyInfoTrackingSystem.Controllers
{ 
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            
            _userManager = userManager;
            _roleManager = roleManager;
        }
        
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterLoginViewModel model)
        {
            var existingUser = await this._userManager.FindByEmailAsync(model.Email);
            if (existingUser == null && model.UserRole == "Employee")
            {
                var user = new IdentityUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (model.UserRole == "Employee")
                    {
                        await _userManager.AddToRoleAsync(user, "Administrator");
                    }
                    return Ok("User Account Created Successfully");
                }
                else
                {
                    return Forbid();
                }
            }
            return Forbid();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(RegisterLoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, model.Password);
            if (user != null && isPasswordCorrect)
            {
                using (var UserRoles = _userManager.GetRolesAsync(user))
                {
                }
                var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
                var authKeySym = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("dlkfhsliow599487658654656dklfhsdkhlfkj"));
                var token = new JwtSecurityToken(
                    claims: authClaims,
                    issuer: "url of your application",
                    audience: "url of your application",
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: new SigningCredentials(authKeySym, SecurityAlgorithms.HmacSha256));
                return Ok(new 
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}