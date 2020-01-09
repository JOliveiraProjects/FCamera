using FCamera.Banco.Domain;
using FCamera.Bancos.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConsigaMais.Bancos.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class BancoController : ControllerBase
    {
        public readonly IBancoApplication _bancoApplication;

        public BancoController(IBancoApplication bancoApplication)
        {
            this._bancoApplication = bancoApplication;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value) { }

    }
}