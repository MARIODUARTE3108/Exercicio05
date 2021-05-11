using Exercicio05.Entities;
using Exercicio05.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicio05.Controllers
{
    public class AlunoController
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDExercicio05;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public void CadastrarAluno()
        {
            try
            {
                Console.WriteLine("\n CADASTRO DE ALUNOS");

                var aluno = new Aluno();

                Console.Write("Informe do Nome do aluno: ");
                aluno.Nome = Console.ReadLine();

                Console.Write("Matrícula do Nome do aluno: ");
                aluno.Matricula = Console.ReadLine();

                Console.Write("Cpf do Nome do aluno: ");
                aluno.Cpf = Console.ReadLine();

                Console.Write("Informe o Id da turma: ");
                aluno.IdTurma = Guid.Parse(Console.ReadLine());

                var alunoRepository = new AlunoRepository();
                alunoRepository.ConnectionString = connectionString;

                alunoRepository.Inserir(aluno);

                Console.WriteLine("\n Aluno Cadastrado com sucesso!");

            }
            catch (Exception e)
            {
                Console.WriteLine("\n Erro:" + e.Message);
            }
        }

        public void AtualizarAluno()
        {
            try
            {
                Console.WriteLine("\n Atualização de aluno: ");

                Console.Write("Informe o Id do aluno: ");
                var idAluno = Guid.Parse(Console.ReadLine());

                var alunoRepository = new AlunoRepository();
                alunoRepository.ConnectionString = connectionString;

                var aluno = alunoRepository.ObterPorId(idAluno);

                if (aluno != null)
                {
                    Console.Write("Informe do Nome do aluno: ");
                    aluno.Nome = Console.ReadLine();

                    Console.Write("Matrícula do Nome do aluno: ");
                    aluno.Matricula = Console.ReadLine();

                    Console.Write("Cpf do Nome do aluno: ");
                    aluno.Cpf = Console.ReadLine();

                    Console.Write("Informe o Id da turma: ");
                    aluno.IdTurma = Guid.Parse(Console.ReadLine());

                    alunoRepository.Atualizar(aluno);

                    Console.WriteLine("\n Aluno atualizado com sucesso! ");

                }
                else
                {
                    Console.WriteLine("\n Aluno não encontrado");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n Erro:" + e.Message);
            }
        }

        public void ExcluirAluno()
        {
            try
            {
                Console.WriteLine("\n Exclusao de Aluno");

                Console.Write("Informe o Id do aluno: ");
                var idAluno = Guid.Parse(Console.ReadLine());

                var alunoRepository = new AlunoRepository();
                alunoRepository.ConnectionString = connectionString;

                var aluno = alunoRepository.ObterPorId(idAluno);

                if (aluno != null)
                {
                    alunoRepository.Excluir(aluno);
                    Console.WriteLine("\n Aluno excluído com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nAluno não encontrado");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n Erro:" + e.Message);
            }
        }

        public void ConsultarAlunos()
        {

            try
            {
                Console.WriteLine("\n Consulta de alunos:");

                var alunoRepository = new AlunoRepository();
                alunoRepository.ConnectionString = connectionString;

                var alunos = alunoRepository.ObterTodos();

                foreach (var item in alunos)
                {
                    Console.WriteLine("Id do aluno...........:" + item.IdAluno);
                    Console.WriteLine("Nome do aluno.........:" + item.Nome);
                    Console.WriteLine("Matrícula do aluno....:" + item.Matricula);
                    Console.WriteLine("Cpf do aluno..........:" + item.Cpf);
                    Console.WriteLine("Id da turma...........:" + item.IdTurma);
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
