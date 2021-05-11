using Exercicio05.Controllers;
using System;

namespace Exercicio05
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n\n*****SISTEMA DE CONTROLE E CADASTRO DE TURMAS E ALUNOS*****");

            var alunoController = new AlunoController();
            var turmaController = new TurmaController();

            Console.WriteLine("(1)CADASTRO E CONTROLE DE TURMA");
            Console.WriteLine("(2)CADASTRO E CONTROLE DE ALUNO");
            Console.WriteLine("(0)SAIR DO SISTEMA");

            Console.Write("\nINFORME A OPÇÃO DESEJADA: ");
            var opcaoCadastro = int.Parse(Console.ReadLine());
            Console.Write("\n ");

            switch (opcaoCadastro)
            {
                case 1:
                    Console.WriteLine("(1) Cadastrar turma");
                    Console.WriteLine("(2) Consultar turma");
                    Console.WriteLine("(3) Atualizar turma");
                    Console.WriteLine("(4) Excluir turma");
                    Console.WriteLine("(0) Sair do sistema");

                    try
                    {
                        Console.Write("\nInforme a opção desejada: ");
                        var opc = int.Parse(Console.ReadLine());
                        Console.Write("\n ");
                        switch (opc)
                        {
                            case 1:
                                turmaController.CadastrarTurma();
                                Main(args);
                                break;

                            case 2:
                                turmaController.ConsultarTurma();
                                Main(args);
                                break;

                            case 3:
                                turmaController.AutualizarTurma();
                                Main(args);
                                break;

                            case 4:
                                turmaController.ExcluirTurma();
                                Main(args);
                                break;

                            case 0:
                                break;
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\n Erro: " + e.Message);
                    }
                    break;

                case 2:
                    Console.WriteLine("(1) Cadastrar aluno");
                    Console.WriteLine("(2) Consultar aluno");
                    Console.WriteLine("(3) Atualizar aluno");
                    Console.WriteLine("(4) Excluir aluno");
                    Console.WriteLine("(0) Sair do sistema");

                    try
                    {
                        Console.Write("\nInforme a opção desejada: ");
                        var opc = int.Parse(Console.ReadLine());
                        Console.Write("\n ");

                        switch (opc)
                        {
                            case 1:
                                alunoController.CadastrarAluno();
                                Main(args);
                                break;

                            case 2:
                                alunoController.ConsultarAlunos();
                                Main(args);
                                break;

                            case 3:
                                alunoController.AtualizarAluno();
                                Main(args);
                                break;

                            case 4:
                                alunoController.ExcluirAluno();
                                Main(args);
                                break;

                            case 0:
                                break;
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\n Erro: " + e.Message);
                    }
                    break;

            }

            Console.ReadKey();
        }

        
    }

        
    
}
