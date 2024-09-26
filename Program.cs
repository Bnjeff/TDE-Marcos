using System;
using tdemarcos;
class Program
{
    static GestaoTarefas sistema = new GestaoTarefas();

    static void Main(string[] args)
    {
        Console.WriteLine("Bem-vindo ao sistema de gestão de tarefas!");

        while (true)
        {
            ExibirMenu();
            var comando = Console.ReadLine();
            ProcessarComando(comando);
        }
    }

    static void ExibirMenu()
    {
        Console.WriteLine("\nEscolha uma opção:");
        Console.WriteLine("1 - Adicionar Usuário");
        Console.WriteLine("2 - Adicionar Tarefa");
        Console.WriteLine("3 - Listar Tarefas");
        Console.WriteLine("4 - Concluir Tarefa");
        Console.WriteLine("5 - Remover Tarefa");
        Console.WriteLine("6 - Sair");
        Console.Write("Opção: ");
    }

    static void ProcessarComando(string comando)
    {
        switch (comando)
        {
            case "1":
                AdicionarUsuario();
                break;

            case "2":
                AdicionarTarefa();
                break;

            case "3":
                ListarTarefas();
                break;

            case "4":
                ConcluirTarefa();
                break;

            case "5":
                RemoverTarefa();
                break;

            case "6":
                Console.WriteLine("Saindo do sistema.");
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }

    static void AdicionarUsuario()
    {
        Console.Write("Digite o nome do usuário: ");
        var nome = Console.ReadLine();
        sistema.AdicionarUsuario(nome);
        Console.WriteLine($"Usuário '{nome}' adicionado.");
    }

    static void AdicionarTarefa()
    {
        Console.Write("Digite o ID da tarefa: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.Write("Digite o título da tarefa: ");
            var titulo = Console.ReadLine();
            Console.Write("Digite a descrição da tarefa: ");
            var descricao = Console.ReadLine();
            Console.Write("Digite o nome do usuário: ");
            var nomeUsuario = Console.ReadLine();

            var tarefa = new Tarefa(id, titulo, descricao);
            var usuario = sistema.GetUsuario(nomeUsuario);
            usuario?.AdicionarTarefa(tarefa);
            Console.WriteLine($"Tarefa '{titulo}' adicionada ao usuário '{nomeUsuario}'.");
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    static void ListarTarefas()
    {
        Console.Write("Digite o nome do usuário: ");
        var nomeUsuario = Console.ReadLine();
        var usuarioListar = sistema.GetUsuario(nomeUsuario);
        if (usuarioListar != null)
        {
            usuarioListar.ListarTarefas();
        }
        else
        {
            Console.WriteLine($"Usuário '{nomeUsuario}' não encontrado.");
        }
    }

    static void ConcluirTarefa()
    {
        Console.Write("Digite o ID da tarefa a ser concluída: ");
        if (int.TryParse(Console.ReadLine(), out int tarefaId))
        {
            Console.Write("Digite o nome do usuário: ");
            var nomeUsuario = Console.ReadLine();
            var usuarioConcluir = sistema.GetUsuario(nomeUsuario);
            var tarefa = usuarioConcluir?.GetTarefa(tarefaId);
            if (tarefa != null)
            {
                tarefa.Concluir();
                Console.WriteLine($"Tarefa ID {tarefaId} concluída.");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    static void RemoverTarefa()
    {
        Console.Write("Digite o ID da tarefa a ser removida: ");
        if (int.TryParse(Console.ReadLine(), out int tarefaId))
        {
            Console.Write("Digite o nome do usuário: ");
            var nomeUsuario = Console.ReadLine();
            var usuarioRemover = sistema.GetUsuario(nomeUsuario);
            usuarioRemover?.RemoverTarefa(tarefaId);
            Console.WriteLine($"Tarefa ID {tarefaId} removida.");
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }
}
