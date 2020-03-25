using System;
using System.Collections.Generic;

namespace SPMedicalGroup.Senai.WebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medico = new HashSet<Medico>();
            Paciente = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }
        public int? IdEmpresa { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Idade { get; set; }
        public bool? Adm { get; set; }
        public string CodigoEmpresa { get; set; }

        public Empresa IdEmpresaNavigation { get; set; }
        public ICollection<Medico> Medico { get; set; }
        public ICollection<Paciente> Paciente { get; set; }
    }
}
