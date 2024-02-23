public class Aplicacion
{
    public List<Usuario> Usuarios { get; set; }

    public Aplicacion()
    {
        Usuarios = new List<Usuario>
        {
            new Usuario("@Pedro"),
            new Usuario("@Jorge"),
            new Usuario("@Fernanda")
        };
    }
}
