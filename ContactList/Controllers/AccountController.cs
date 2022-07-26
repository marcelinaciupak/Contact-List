using AutoMapper;
using ContactList.Database.Models;
using ContactList.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _signInManager;
        public readonly IMapper _mapper;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost("registration")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] CreateApplicationUserDto newUser)
        {
            var applicationUser = _mapper.Map<ApplicationUser>(newUser);
            var result = await _userManager.CreateAsync(applicationUser, newUser.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(applicationUser, newUser.UserRoles);

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
                _userManager.ConfirmEmailAsync(applicationUser, token);

                return Ok(result);
            }
            return ValidationProblem();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginApplicationUserDto loginUser)
        {
            var foundUser = await _userManager.FindByEmailAsync(loginUser.Email);

            if (foundUser == null)
            {
                return NotFound();
            }
            var result = await _signInManager.PasswordSignInAsync(foundUser, loginUser.Password, true, false);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpDelete("logout")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();

                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCurrent()
        {
            var user = await _userManager.GetUserAsync(User);
            return Ok(user);
        }
    }
}
