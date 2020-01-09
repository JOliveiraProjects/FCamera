﻿using FCamera.Application.Interfaces;
using FCamera.Application.ViewModels;
using FCamera.Common.Interfaces;
using FCamera.Common.Models;
using FCamera.Domain.Entities;
using FCamera.Domain.Interfaces;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FCamera.Application
{
    public class AutenticaApplication : IAutenticaApplication
    {
        private readonly IAutenticaRepository _autenticaRepository;
        private readonly ITokenApplication _tokenService;
        private readonly IPasswordHasherServices _passwordHasher;

        public AutenticaApplication(IAutenticaRepository autenticaRepository, 
            ITokenApplication tokenService, 
            IPasswordHasherServices passwordHasher)
        {
            _autenticaRepository = autenticaRepository;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task<ResultModel<TokenViewModel>> Autenticar(string username, string password)
        {
            ResultModel<TokenViewModel> result = new ResultModel<TokenViewModel>();

            try
            {
                AutenticaModel user = await _autenticaRepository.GetUsuario(u => u.Nome == username);

                if (user == null || !_passwordHasher.VerifyIdentityV3Hash(password, user.Senha))
                    throw new Exception("Não encontrado nenhum usuário!");

                Claim[] usersClaims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Nome),
                    new Claim(ClaimTypes.NameIdentifier, user.UsuarioId.ToString())
                };

                TokenViewModel jwtToken = _tokenService.GenerateAccessToken(usersClaims);
                string refreshToken = _tokenService.GenerateRefreshToken();
                jwtToken.RefreshToken = refreshToken;
                user.RefreshToken = refreshToken;

                await _autenticaRepository.UpdateUsuario(user);
                result.Resultado = jwtToken;

                return result;
            }
            catch (Exception ex)
            {
                result.Inconsistencias.Add(ex.Message);
            }

            return result;
        }

        public async Task<ResultModel<TokenViewModel>> AtualizaToken(string token, string refreshToken)
        {
            ResultModel<TokenViewModel> result = new ResultModel<TokenViewModel>();

            try
            {
                ClaimsPrincipal principal = _tokenService.GetPrincipalFromExpiredToken(token);
                string username = principal.Identity.Name;

                AutenticaModel user = await _autenticaRepository.GetUsuario(u => u.Nome == username);

                if (user == null || user.RefreshToken != refreshToken)
                {
                    result.Inconsistencias.Add("Não foi possivel atualiza o token.");
                    return result;
                }

                TokenViewModel jwtToken = _tokenService.GenerateAccessToken(principal.Claims);
                string newRefreshToken = _tokenService.GenerateRefreshToken();
                jwtToken.RefreshToken = newRefreshToken;
                user.RefreshToken = newRefreshToken;
                await _autenticaRepository.UpdateUsuario(user);
                result.Resultado = jwtToken;
            }
            catch (Exception ex)
            {
                result.Inconsistencias.Add(ex.Message);
            }

            return result;
        }
    }
}
