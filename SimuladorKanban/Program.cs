using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorKanban
{
    internal class Program
    {
         static int opcao = 0;
        static string novaTarefa;

         static List<string> tarefasAFazer = new List<string>();
         static List<string> tarefasEmProgresso = new List<string>();
         static List<string> tarefasConcluidas = new List<string>();
        static void Main(string[] args)

        {
            

            
            while (true)

            {

                Console.WriteLine("Sistema de Gestão de Tarefas \n" );
                Console.WriteLine("1 - Adicionar nova tarefa");
                Console.WriteLine("2 - Exibir tarefas");
                Console.WriteLine("3 - Mover tarefa");
                Console.WriteLine("4 - Sair \n");

                Console.WriteLine("Escolha uma das opções acima");
                if (int.TryParse(Console.ReadLine(), out opcao))
                {


                    switch (opcao)
                    {
                        case 1:
                            inserirTarefa();

                            break;
                        case 2:
                            listarTarefas();
                            break;
                        case 3:
                            moverTarefa();
                            break;
                        case 4:
                            Console.WriteLine("Finalizando o Sistema de Gestão de Tarefas");
                            return;
                        default:
                            Console.WriteLine("Opção inválida. Digite um número novamente. ");
                            break;
                    }
                } else
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número.");
                }
            }
        }

        public static void inserirTarefa()
        {
            Console.WriteLine("Digite uma nova tarefa:");
            novaTarefa = Console.ReadLine();
            tarefasAFazer.Add(novaTarefa);
            Console.WriteLine("Tarefa adicionada com sucesso! \n2" +
                "");
        }

        public static void listarTarefas ()
        {
            if (tarefasAFazer.Count == 0 && tarefasEmProgresso.Count == 0 && tarefasConcluidas.Count == 0 )
            {
                Console.WriteLine("Não há tarefa cadastrada. \n");
            } else
            {   
                Console.WriteLine("Quadro de Tarefas \n");

                if(tarefasAFazer.Count > 0)
                {
                    Console.WriteLine("Tarefas a Fazer: ");
                    foreach (string tarefa in tarefasAFazer)
                    {
                        Console.WriteLine(tarefa);
                        Console.WriteLine();
                    }
                }

                if(tarefasEmProgresso.Count > 0)
                {
                    Console.WriteLine("Tarefas em Progresso: ");
                    foreach (string tarefa in tarefasEmProgresso)
                    {
                        Console.WriteLine(tarefa);
                        Console.WriteLine();
                    }
                }
                
                if(tarefasConcluidas.Count > 0)
                {
                    Console.WriteLine("Tarefas Concluidas: ");
                    foreach (string tarefa in tarefasConcluidas)
                    {
                        Console.WriteLine(tarefa);
                        Console.WriteLine();
                    }
                }
                
            }
        }

        public static void moverTarefa()
        {
            Console.WriteLine("Digite o nome da tarefa que deseja mover:");
            string tarefaParaMover = Console.ReadLine();

            if (tarefasAFazer.Remove(tarefaParaMover))
            {
                tarefasEmProgresso.Add(tarefaParaMover);
                Console.WriteLine("Tarefa movida para 'Em Progresso'.");
            }
            else if (tarefasEmProgresso.Remove(tarefaParaMover))
            {
                tarefasConcluidas.Add(tarefaParaMover);
                Console.WriteLine("Tarefa movida para 'Concluídas'.");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
        }
    }
}
