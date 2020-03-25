using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SPMedicalGroup.Senai.WebApi.Domains;
using SPMedicalGroup.Senai.WebApi.Repositorio;

namespace SPMedicalGroup.Senai.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        UsuarioRepositorio Connect = new UsuarioRepositorio();


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(Usuario validar)
        {

            Usuario usuario = Connect.Autenticar(validar.Email, validar.Senha);

            if (usuario != null)
            {
                string categoria;
                var email = usuario.Email;
                var id = usuario.IdUsuario.ToString();

                if (usuario.Adm == true)
                {
                    categoria = "Administrador";
                }
                else
                {
                    categoria = "Comum";
                }
                

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim(JwtRegisteredClaimNames.Jti, id),
                    new Claim(ClaimTypes.Role, categoria)
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("9d1f71ad00ffb3977d61ba56e44d4e6f"));
                var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer:"SPMedicalGroup.Senai.WebApi",
                    audience:"SPMedicalGroup.Senai.WebApi",
                    claims:claims,
                    expires:DateTime.Now.AddMinutes(10),
                    signingCredentials: credencial
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            else
            {
                IActionResult response = NotFound("Dados inválidos");
                return response;
            }
        }
    }
}

