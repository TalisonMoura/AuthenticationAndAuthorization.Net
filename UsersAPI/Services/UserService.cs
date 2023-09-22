using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersAPI.Data.Dtos;
using UsersAPI.Models;

namespace UsersAPI.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Register(CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded) { throw new ApplicationException("Failed to register the user"); }
        }

        public async Task<string> Login(LoginUserDto loginUserDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUserDto.Username, loginUserDto.Password, false, false);
            if (!result.Succeeded) { throw new ApplicationException("User not authenticated"); }
            var user = 
                _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user => user.NormalizedUserName == loginUserDto.Username.ToUpper());
            var token = _tokenService.GenerateToken(user);
            return token;
        }


    }
}
