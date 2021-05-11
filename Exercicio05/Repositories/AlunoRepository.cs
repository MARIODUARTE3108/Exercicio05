using Exercicio05.Entities;
using Exercicio05.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace Exercicio05.Repositories
{
    class AlunoRepository : IAluno
    {
        public string ConnectionString {get; set; }
        public void Atualizar(Aluno aluno)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("SP_ATUALIZARALUNO",
                    new
                    {
                        @IDALUNO = aluno.IdAluno,
                        @NOME = aluno.Nome,
                        @MATRICULA = aluno.Matricula,
                        @CPF = aluno.Cpf,
                        @IDTURMA = aluno.IdTurma
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Excluir(Aluno aluno)
        {
            using(var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("SP_EXCLUIRALUNO",
                    new
                    {
                        @IDALUNO = aluno.IdAluno
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Inserir(Aluno aluno)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("SP_INSERIRALUNO",
                    new
                    {
                        @NOME = aluno.Nome,
                        @MATRICULA = aluno.Matricula,
                        @CPF = aluno.Cpf,
                        @IDTURMA = aluno.IdTurma
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Aluno ObterPorId(Guid idAluno)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<Aluno>("SP_OBTERALUNOPORID",
                    new
                    {
                        @IDALUNO = idAluno
                    },
                     commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<Aluno> ObterTodos()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<Aluno>("SP_OBTERALUNO",
                commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
