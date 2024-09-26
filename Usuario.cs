using System;
using tdemarcos;

public class Usuario
{
    public string Nome { get; private set; }
    private List<Tarefa> Tarefas { get; set; }

    public Usuario(string nome)
    {
        Nome = nome;
        Tarefas = new List<Tarefa>();
    }

    public void AdicionarTarefa(Tarefa tarefa)
    {
        Tarefas.Add(tarefa);
    }

    public void RemoverTarefa(int tarefaId)
    {
        Tarefas.RemoveAll(t => t.Id == tarefaId);
    }

    public void ListarTarefas()
    {
        foreach (var tarefa in Tarefas)
        {
            System.Console.WriteLine(tarefa);
        }
    }

    public Tarefa GetTarefa(int id)
    {
        return Tarefas.Find(t => t.Id == id);
    }
}
