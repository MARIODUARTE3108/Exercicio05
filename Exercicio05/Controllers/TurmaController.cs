using Exercicio05.Entities;
using Exercicio05.Repositories;
using System;

namespace Exercicio05
{
    public class TurmaController
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDExercicio05;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public void CadastrarTurma()
        {
            try
            {
                Console.WriteLine("\n\nCadastro de Turma ");

                var turma = new Turma();

                Console.Write("Informe o nome da turma: ");
                turma.Nome = Console.ReadLine();

                Console.Write("Informe a data de início da turma: ");
                turma.DataInicio = DateTime.Parse(Console.ReadLine());

                Console.Write("Informe a data do fim da turma: ");
                turma.DataFim = DateTime.Parse(Console.ReadLine());

                var turmarepository = new TurmaRepository();
                turmarepository.ConnectionString = connectionString;

                turmarepository.Inserir(turma);

                Console.WriteLine("\n Turma cadastrada com sucesso!");

            }
            catch (Exception e)
            {
                Console.WriteLine("\n Erro:" + e.Message);
            }
        }

        public void AutualizarTurma()
        {
            try
            {
                Console.WriteLine("\n\n Atualização de Turma ");

                Console.Write("Informe o Id da turma: ");
                var idTurma = Guid.Parse(Console.ReadLine());

                var turmaRepository = new TurmaRepository();
                turmaRepository.ConnectionString = connectionString;

                var turma = turmaRepository.ObterPorId(idTurma);

                if (turma != null)
                {
                    Console.Write("Informe do Nome da turma: ");
                    turma.Nome = Console.ReadLine();

                    Console.Write("Data de início da turma: ");
                    turma.DataInicio = DateTime.Parse(Console.ReadLine());

                    Console.Write("Data de fim da turma: ");
                    turma.DataFim = DateTime.Parse(Console.ReadLine());

                    turmaRepository.Atualizar(turma);

                    Console.WriteLine("\n Turma atualizada com sucesso! ");

                }
                else
                {
                    Console.WriteLine("\n Turma não encontrado");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n Erro:" + e.Message);
            }
        }

        public void ExcluirTurma()
        {
            try
            {
                Console.WriteLine("\n\n Exclusão de turma");

                Console.Write("Informe o Id da turma: ");
                var idTurma = Guid.Parse(Console.ReadLine());

                var turmaRepository = new TurmaRepository();
                turmaRepository.ConnectionString = connectionString;

                var turma = turmaRepository.ObterPorId(idTurma);

                if (turma != null)
                {
                    turmaRepository.Excluir(turma);
                    Console.WriteLine("\n Turma excluída com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nTurma não encontrada");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n Erro:" + e.Message);
            }
        }

        public void ConsultarTurma()
        {

            try
            {
                Console.WriteLine("\n\n Consulta de turmas:");

                var turmaRepository = new TurmaRepository();
                turmaRepository.ConnectionString = connectionString;

                var turmas = turmaRepository.ObterTodos();

                foreach (var item in turmas)
                {
                    Console.WriteLine("Id da turma...........:" + item.IdTurma);
                    Console.WriteLine("Nome da turma.........:" + item.Nome);
                    Console.WriteLine("Data de início........:" + item.DataInicio);
                    Console.WriteLine("Data de fim...........:" + item.DataFim);
                    Console.WriteLine("--------------\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n Erro:" + e.Message);
            }
        }

    }
}
