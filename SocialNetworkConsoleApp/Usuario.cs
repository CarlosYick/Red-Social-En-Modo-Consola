public class Usuario
{
    public string Nombre { get; set; }
    public List<Mensaje> Mensajes { get; set; }
    public List<Usuario> UsuariosSeguidos { get; set; }

    public Usuario(string nombre)
    {
        Nombre = nombre;
        Mensajes = new List<Mensaje>();
        UsuariosSeguidos = new List<Usuario>();
    }
}
