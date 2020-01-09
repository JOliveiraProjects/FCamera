using FCamera.Application.Interfaces;
using FCamera.Application.ViewModels;
using FCamera.Autentica.API.Enums;
using FCamera.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FCamera.Autentica.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticaController : ControllerBase
    {
        private readonly IAutenticaApplication _autenticaApplication;

        public AutenticaController(IAutenticaApplication autenticaApplication)
        {
            _autenticaApplication = autenticaApplication;
        }

        /// <summary>
        /// Autentica para ter acesso as APIs.
        /// <remarks>
        /// Exemplo:
        ///
        ///
        /// </remarks>
        /// </summary>
        /// <param name="loginParam"></param>
        /// <response code="200">Retorna as informações do token privado</response>
        /// <response code="400">Se o token privado não for criado</response>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Post([FromBody] AutenticaViewModel model,
        [FromHeader(Name = "x-grant-type")] GrantType grantType = GrantType.Password,
        [FromHeader(Name = "x-token")] string token = null,
        [FromHeader(Name = "x-refresh-token")] string refreshToken = null)
        {
            ResultModel<TokenViewModel> result = new ResultModel<TokenViewModel>();

            if (grantType == GrantType.RefreshToken)
            {
                if(string.IsNullOrEmpty(token) && string.IsNullOrEmpty(refreshToken))
                {
                    result.Inconsistencias.Add("Precisa passar o token e o refresh token.");
                }
                else
                {
                    result = await _autenticaApplication.AtualizaToken(token, refreshToken);
                }
            }
            else if (grantType == GrantType.Password)
            {
                if (model == null || (string.IsNullOrEmpty(model.Usuario) && string.IsNullOrEmpty(model.Senha)))
                {
                    result.Inconsistencias.Add("Não preencheu os dados de autenticação.");
                }
                else
                {
                    result = await _autenticaApplication.Autenticar(model.Usuario, model.Senha);
                }
            }

            if (!result.Sucesso)
                return BadRequest(result);

            return Ok(result.Resultado);
        }
    }
}
