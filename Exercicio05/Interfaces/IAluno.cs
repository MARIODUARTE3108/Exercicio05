using Exercicio05.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio05.Interfaces
{
    public interface IAluno
    {
        void Inserir(Aluno aluno);
        void Atualizar(Aluno aluno);
        void Excluir(Aluno aluno);

        List<Aluno> ObterTodos();

        Aluno ObterPorId(Guid idAluno);

    }
}
