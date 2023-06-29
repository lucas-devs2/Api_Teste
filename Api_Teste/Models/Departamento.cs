using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Teste.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EmpresaId { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
    }
}
