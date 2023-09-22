using Microsoft.AspNetCore.Identity;

namespace UsersAPI.Models
{
    public class User : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }
        public User() : base() { }
    }
}
