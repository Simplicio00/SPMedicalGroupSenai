using System;
using System.Collections.Generic;

namespace SPMedicalGroup.Senai.WebApi.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public string TituloConsulta { get; set; }
        public string SituacaoConsulta { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Relatorio { get; set; }

        public Medico IdMedicoNavigation { get; set; }
        public Paciente IdPacienteNavigation { get; set; }
    }
}
