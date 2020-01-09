using FCamera.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FCamera.Domain.Interfaces
{
    public interface IAutenticaRepository
    {
        Task AddUsuario(AutenticaModel usuario);
        Task UpdateUsuario(AutenticaModel usuario);
        Task<IList<AutenticaModel>> GetUsuarios();
        Task<AutenticaModel> GetUsuario(string username, string password);
        Task<AutenticaModel> GetUsuario(Expression<Func<AutenticaModel, bool>> predicate);
        Task<AutenticaModel> GetUsuarioById(int usuarioId);
    }
}
