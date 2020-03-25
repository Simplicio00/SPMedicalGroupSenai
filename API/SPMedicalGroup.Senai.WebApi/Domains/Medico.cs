using System;
using System.Collections.Generic;

namespace SPMedicalGroup.Senai.WebApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdMedico { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEspecialidade { get; set; }
        public string NomeMedico { get; set; }
        public string Crm { get; set; }

        public Especialidade IdEspecialidadeNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
    }
}
