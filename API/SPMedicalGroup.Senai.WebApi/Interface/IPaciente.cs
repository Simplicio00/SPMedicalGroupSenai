using SPMedicalGroup.Senai.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Senai.WebApi.Interface
{
	interface IPaciente
	{
		void CadPaciente(Paciente paciente);

		List<Paciente> GetPaciente();

		Paciente GetPacienteIndividual(int id);

		Paciente ModificarPaciente(int id, Paciente paciente);
	}
}
