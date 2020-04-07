using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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

        [Authorize(Roles = "Administrador")]
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


        [HttpGet("Medicos")]
        public IActionResult GetMedicos()
        {
            IActionResult empty = NoContent();
            var lista = connect.GetMedicos();
            if (lista.Count != 0)
            {
                return Ok(lista);
            }
            else
            {
                return empty;
            }
        }


        [HttpGet("Pacientes")]
        public IActionResult GetPacientes()
        {
            IActionResult empty = NoContent();
            var lista = connect.GetPaciente();
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
            Random random = new Random();
            var especialidade = random.Next(1, 18);

            if (!lista.Contains(lista.FirstOrDefault(valor => valor.Email == usuario.Email)))
            {
                try
                {
                    usuario.IdEmpresa = 1;
                    connect.Cadastro(usuario);

                    if (usuario.CodigoEmpresa == "SPMedicalGroup5561x")
                    {
                        Medico medico = new Medico()
                        {
                            IdUsuario = usuario.IdUsuario,
                            NomeMedico = "Modifique o seu nome",
                            Crm = "xxxxxxxx",
                            IdEspecialidade = especialidade
                        };
                        connect.CadMedico(medico);
                        return Ok($"O Usuário E-Mail: {usuario.Email} foi cadastrado como médico, o código {usuario.CodigoEmpresa} foi validado! ");
                    }
                    else
                    {
                        Paciente paciente = new Paciente()
                        {
                            IdUsuario = usuario.IdUsuario,
                            NomePaciente = "Modifique o seu nome",
                            Rg = "xxxxxxx",
                            Telefone = "xxxxxx",
                            Endereco = "xxxxxxx",
                            Cpf = "xxxxxxx"
                        };
                        connect.CadPaciente(paciente);
                        return Ok($"O Usuário E-Mail: {usuario.Email} foi cadastrado como Paciente, modifique as suas informações");
                    }
                }
                catch (Exception ex)
                {
                    return Forbid($"Ocorreu um erro na hora de cadastrar: {ex.Message.ToString()}");
                }
            }
            else
            {
                return BadRequest("Este endereço de E-Mail já está cadastrado no sistema.");
            }
        }



        [HttpPut]
        public IActionResult ModificarSenha(Usuario usuario)
        {
            var idUser = HttpContext.User.Claims.First(a => a.Type == "jti").Value;

            try
            {
                connect.Modificar(int.Parse(idUser), usuario);
                return Ok(string.Format($" Senha modificada "));
            }
            catch (Exception ex)
            {
                IActionResult result = Forbid(ex.Message);
                return result;
            }
        }


        [HttpPut("Medico")]
        public IActionResult ModificarMedico(Medico medico)
        {
            var idUser = HttpContext.User.Claims.First(a => a.Type == "jti").Value;

            try
            {
                connect.ModificarMedico(int.Parse(idUser), medico);
                return Ok(string.Format($" O usuário {medico.NomeMedico} foi  modificado! "));
            }
            catch (Exception ex)
            {
                IActionResult result = Forbid(ex.Message);
                return result;
            }
        }



        [HttpPut("Paciente")]
        public IActionResult ModificarPaciente(Paciente paciente)
        {
            var idUser = HttpContext.User.Claims.First(a => a.Type == "jti").Value;

            try
            {
                connect.ModificarPaciente(int.Parse(idUser), paciente);
                return Ok(string.Format($" O usuário {paciente.NomePaciente} foi  modificado! "));
            }
            catch (Exception ex)
            {
                IActionResult result = Forbid(ex.Message);
                return result;
            }
        }


        [HttpGet("Perfil")]
        public IActionResult MinhaInfo()
        {
            var idUser = HttpContext.User.Claims.First(a => a.Type == "jti").Value;

            try
            { 
                var sePaciente = connect.GetMedicoIndividual(int.Parse(idUser));
                var seMedico = connect.GetPacienteIndividual(int.Parse(idUser));

                if (sePaciente != null)
                {
                    return Ok(sePaciente);
                }
                else if(seMedico != null)
                {
                    return Ok(seMedico);
                }
                else
                {
                    var adm = connect.GetUsuario(int.Parse(idUser));
                    return Ok(adm);
                }

            }
            catch (Exception ex)
            {
                IActionResult result = BadRequest($"Ocorreu um erro: {ex.Message}");
                return result;
            }
        }



    }
}