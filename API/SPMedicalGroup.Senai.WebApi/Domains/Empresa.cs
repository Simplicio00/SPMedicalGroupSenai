using System;
using System.Collections.Generic;

namespace SPMedicalGroup.Senai.WebApi.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdEmpresa { get; set; }
        public string NomeEmpresa { get; set; }
        public string Cnpj { get; set; }
        public string EnderecoEmpresa { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
