using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPMedicalGroup.Senai.WebApi.Domains;
using SPMedicalGroup.Senai.WebApi.Repositorio;

namespace SPMedicalGroup.Senai.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        UsuarioRepositorio connect = new UsuarioRepositorio();

        [Authorize(Roles ="Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult empty = NoContent();
            var lista = connect.Get();

            if (lista.Count != 0)
            {
                return Ok(lista);
            }
            else
            {
                return empty;
            }
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            var lista = connect.Get();
            IActionResult result = BadRequest("Este endereço de E-Mail já está cadastrado");


            if (!lista.Contains(lista.FirstOrDefault(valor => valor.Email == usuario.Email)))
            {
                try
                {
                    connect.Cadastro(usuario);
                    return Ok($"O usuário com email:{usuario.Email} e senha: {usuario.Senha}, foi cadastrado com sucesso");
                }
                catch (Exception ex)
                {
                    return Forbid($"Ocorreu um erro na hora de cadastrar: {ex.Message.ToString()}");
                }
            }
            else
            {
                return result;
            }
        }
    }
}