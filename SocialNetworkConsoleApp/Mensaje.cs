public class Mensaje
{
    public string Contenido { get; set; }
    public DateTime HoraDePublicacion { get; set; }
    public Usuario Usuario { get; set; }

    public Mensaje(string contenido, DateTime horaDePublicacion, Usuario usuario)
    {
        Contenido = contenido;
        HoraDePublicacion = horaDePublicacion;
        Usuario = usuario;
    }
}
