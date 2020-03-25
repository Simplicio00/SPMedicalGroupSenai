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



		//Médicos

		public List<Medico> GetMedicos()
		{
			try
			{
				return Connect.Medico.ToList();
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




		//Pacientes

		public void CadPaciente(Paciente paciente)
		{
			Connect.Add(paciente);
			Connect.SaveChanges();
		}


		public List<Paciente> GetPaciente()
		{
			try
			{
				return Connect.Paciente.ToList();
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}
