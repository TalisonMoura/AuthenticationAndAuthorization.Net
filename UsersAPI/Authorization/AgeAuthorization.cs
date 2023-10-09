using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UsersAPI.Authorization
{
    public class AgeAuthorization : AuthorizationHandler<MinimumAge>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAge requirement)
        {
            var dateOfBirthClaim = context
                .User.FindFirst(claim => claim.Type.Equals(ClaimTypes.DateOfBirth));

            if (dateOfBirthClaim is null) { return Task.CompletedTask; }
            var dateOfBirth = Convert.ToDateTime(dateOfBirthClaim.Value);
            var userAge = DateTime.Today.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Today.AddYears(-userAge)) userAge--;
            if (userAge >= requirement.Age) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
