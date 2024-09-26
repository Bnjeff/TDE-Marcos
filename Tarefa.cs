using System; 
namespace tdemarcos{
using System;

public class Tarefa
{
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public bool Concluida { get; private set; }

    public Tarefa(int id, string titulo, string descricao)
    {
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        Concluida = false;
    }

    public void Concluir()
    {
        Concluida = true;
    }

    public override string ToString()
    {
        string status = Concluida ? "Concluída" : "Pendente";
        return $"[{Id}] {Titulo} - {status}\nDescrição: {Descricao}";
    }
}


}




