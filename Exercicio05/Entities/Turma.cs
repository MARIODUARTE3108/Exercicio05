﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio05.Entities
{
    public class Turma
    {
        public Guid IdTurma { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public List<Aluno> Alunos { get; set; }
    }
}
