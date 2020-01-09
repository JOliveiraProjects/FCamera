using FCamera.Bancos.Application;
using Microsoft.Extensions.Configuration;

namespace FCamera.Bancos.Repository
{
    public class BancoApplication : IBancoApplication
    {
        public IConfiguration _configuration { get; }

        public BancoApplication(IConfiguration configuration)
        {
            this._configuration = configuration; 
        }

    }
}
