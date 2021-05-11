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
    class TurmaRepository : ITurma
    {
        public string ConnectionString { get; set; }
        public void Atualizar(Turma turma)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("SP_ATUALIZARTURMA",
                    new
                    {
                        @IDTURMA = turma.IdTurma,
                        @NOME = turma.Nome,
                        @DATAINICIO = turma.DataInicio,
                        @DATAFIM = turma.DataFim
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Excluir(Turma turma)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("SP_EXCLUIRTURMA",
                    new
                    {
                        @IDTURMA = turma.IdTurma
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
        public void Inserir(Turma turma)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("SP_INSERIRTURMA",
                    new
                    {
                        @NOME = turma.Nome,
                        @DATAINICIO = turma.DataInicio,
                        @DATAFIM = turma.DataFim
                    },
                    commandType: CommandType.StoredProcedure);

            }
        }
            public Turma ObterPorId(Guid idTurma)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<Turma>("SP_OBTERTURMAPORID",
                    new
                    {
                        @IDTURMA = idTurma
                    },
                     commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

        }

        public List<Turma> ObterTodos()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<Turma>("SP_OBTERTURMA",
                commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
