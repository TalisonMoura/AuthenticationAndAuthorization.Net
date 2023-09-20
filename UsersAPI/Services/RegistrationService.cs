using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersAPI.Data.Dtos;
using UsersAPI.Models;

namespace UsersAPI.Services
{
    public class RegistrationService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;

        public RegistrationService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task Register(CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded)
            {
                throw new ApplicationException("Failed to register the user");
            }  
        }




    }
}
