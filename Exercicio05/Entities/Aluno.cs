using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio05.Entities
{
    public class Aluno
    {
        public Guid IdAluno { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Cpf { get; set; }
        public Guid IdTurma { get; set; }
    }
}
