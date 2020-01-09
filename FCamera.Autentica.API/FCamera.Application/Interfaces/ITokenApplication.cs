using FCamera.Application.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;

namespace FCamera.Application.Interfaces
{
    public interface ITokenApplication
    {
        TokenViewModel GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}