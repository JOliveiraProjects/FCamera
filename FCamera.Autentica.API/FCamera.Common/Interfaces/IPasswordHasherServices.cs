using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace FCamera.Common.Interfaces
{
    public interface IPasswordHasherServices
    {
         string GenerateIdentityV3Hash(string password, KeyDerivationPrf prf = KeyDerivationPrf.HMACSHA256, int iterationCount = 10000, int saltSize = 16);
         bool VerifyIdentityV3Hash(string password, string passwordHash);
    }
}