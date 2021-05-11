using Exercicio05.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio05.Interfaces
{
    public interface ITurma
    {
        void Inserir(Turma turma);
        void Atualizar(Turma turma);
        void Excluir(Turma turma);

        List<Turma> ObterTodos();

        Turma ObterPorId(Guid idTurma);
    }
}
