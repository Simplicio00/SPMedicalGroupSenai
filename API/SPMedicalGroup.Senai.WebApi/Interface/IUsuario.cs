using SPMedicalGroup.Senai.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Senai.WebApi.Interface
{
	interface IUsuario
	{
		Usuario Autenticar(string email, string senha);

		List<Usuario> Get();

		Usuario Cadastro(Usuario usuario);
	}
}
