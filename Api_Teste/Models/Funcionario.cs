using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Teste.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EmpresaId { get; set; }
        public int DepartamentoId { get; set; }
        public List<Tarefas> Tarefas { get; set; }
    }
}
