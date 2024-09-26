using System;
using tdemarcos;

public class GestaoTarefas
{
    private Dictionary<string, Usuario> Usuarios { get; set; }

    public GestaoTarefas()
    {
        Usuarios = new Dictionary<string, Usuario>();
    }

    public void AdicionarUsuario(string nome)
    {
        if (!Usuarios.ContainsKey(nome))
        {
            Usuarios[nome] = new Usuario(nome);
        }
    }

    public Usuario GetUsuario(string nome)
    {
        Usuarios.TryGetValue(nome, out var usuario);
        return usuario;
    }
}
