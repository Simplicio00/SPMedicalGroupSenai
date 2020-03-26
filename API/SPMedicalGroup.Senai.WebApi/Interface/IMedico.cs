using SPMedicalGroup.Senai.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Senai.WebApi.Interface
{
	interface IMedico
	{
		void CadMedico(Medico medico);

		List<Medico> GetMedicos();

		Medico GetMedicoIndividual(int id);

		Medico ModificarMedico(int id, Medico medico);
	}
}
