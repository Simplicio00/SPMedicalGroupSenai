using Microsoft.EntityFrameworkCore;
using SPMedicalGroup.Senai.WebApi.Domains;
using SPMedicalGroup.Senai.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Senai.WebApi.Repositorio
{
	public class UsuarioRepositorio : IUsuario, IMedico, IPaciente
	{
		ConnectDBContext Connect = new ConnectDBContext();

		public Usuario Autenticar(string email, string senha)
		{
			try
			{
				var usr = Connect.Usuario.Where(aut => aut.Email == email && aut.Senha == senha).FirstOrDefault();
				return usr;
			}
			catch (Exception)
			{
				return null;
			}
			
		}

		public List<Usuario> Get()
		{
			try
			{
				return Connect.Usuario.ToList();
			}
			catch (Exception)
			{
				return null;
			}
		}


		public Usuario Cadastro(Usuario usuario)
		{
			try
			{
				Connect.Add(usuario);
				Connect.SaveChanges();
				return usuario;
			}
			catch (Exception)
			{
				return null;
			}
		}


		public Usuario Modificar(int id, Usuario usuario)
		{
			try
			{
				Usuario usuario1 = Connect.Usuario.FirstOrDefault(re => re.IdUsuario == id);

				if (usuario.Senha != null && usuario.Idade != 0)
				{
					usuario1.Senha = usuario.Senha;
					usuario1.Idade = usuario.Idade;
					Connect.Update(usuario1);
					Connect.SaveChanges();
				}
				else if (usuario.Senha == null)
				{
					usuario1.Idade = usuario.Idade;
					Connect.Update(usuario1);
					Connect.SaveChanges();
				}
				else if (usuario.Idade == 0)
				{
					usuario1.Senha = usuario.Senha;
					Connect.Update(usuario1);
					Connect.SaveChanges();
				}
				
				return usuario1;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public Usuario GetUsuario(int id)
		{
			return Connect.Usuario.FirstOrDefault(a => a.IdUsuario == id);
		}
		


		//
		//Médicos
		//

		public List<Medico> GetMedicos()
		{
			try
			{
				return Connect.Medico.Include(a => a.IdEspecialidadeNavigation).Include(a => a.IdUsuarioNavigation).ToList();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public void CadMedico(Medico medico)
		{
			Connect.Add(medico);
			Connect.SaveChanges();
		}


		public Medico GetMedicoIndividual(int id)
		{
			return Connect.Medico.FirstOrDefault(medico => medico.IdMedico == id);
		}


		public Medico ModificarMedico(int id, Medico medico)
		{
			try
			{
				Medico medico1 = Connect.Medico.FirstOrDefault(md => md.IdMedico == id);
				medico1 = medico;
				Connect.Update(medico1);
				Connect.SaveChanges();
				return medico1;
			}
			catch (Exception)
			{
				return null;
			}
		}



		//
		//Pacientes
		//

		public void CadPaciente(Paciente paciente)
		{
			Connect.Add(paciente);
			Connect.SaveChanges();
		}


		public List<Paciente> GetPaciente()
		{
			try
			{
				return Connect.Paciente.Include(a => a.IdUsuarioNavigation).ToList();
			}
			catch (Exception)
			{
				return null;
			}
		}

	}
}
