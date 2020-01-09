using FCamera.Application.ViewModels;
using FCamera.Common.Models;
using System.Threading.Tasks;

namespace FCamera.Application.Interfaces
{
    public interface IAutenticaApplication
    {
        Task<ResultModel<TokenViewModel>> Autenticar(string username, string password);
        Task<ResultModel<TokenViewModel>> AtualizaToken(string token, string refreshToken);
    }
}
