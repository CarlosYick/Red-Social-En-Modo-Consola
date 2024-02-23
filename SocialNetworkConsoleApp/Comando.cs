public class Comando{

    private Aplicacion Aplicacion;

        public Comando()
    {
        this.Aplicacion = new Aplicacion();
    }

    public Comando(Aplicacion aplicacion)
    {
    this.Aplicacion = aplicacion;
    }

public void Post(string nombreUsuario, string contenido)
{
    Usuario usuario = Aplicacion.Usuarios.Find(u => u.Nombre == nombreUsuario);
    if (usuario == null)
    {
        throw new Exception("El usuario " + nombreUsuario + " no existe.");
    }

    if (contenido == null)
    {
        throw new Exception("Contenido no disponible");
    }

    Mensaje mensaje = new Mensaje(contenido, DateTime.Now, usuario);
    usuario.Mensajes.Add(mensaje);

    Console.WriteLine(nombreUsuario + " posted -> \"" + contenido + "\" @" + mensaje.HoraDePublicacion.ToString("HH:mm"));
}


public void Follow(string nombreUsuario, string nombreUsuarioASeguir)
{
    Usuario usuario = Aplicacion.Usuarios.Find(u => u.Nombre == nombreUsuario);
    Usuario usuarioASeguir = Aplicacion.Usuarios.Find(u => u.Nombre == nombreUsuarioASeguir);

    if (usuario == null)
    {
        throw new Exception("El usuario " + nombreUsuario + " no existe.");
    }

    if (usuarioASeguir == null)
    {
        throw new Exception("El usuario " + nombreUsuarioASeguir + " no existe.");
    }

    usuario.UsuariosSeguidos.Add(usuarioASeguir);

    Console.WriteLine(nombreUsuario + " empezó a seguir a " + nombreUsuarioASeguir);
}

public void Dashboard(string nombreUsuario)
{
    Usuario usuario = Aplicacion.Usuarios.Find(u => u.Nombre == nombreUsuario);
    if (usuario == null)
    {
        Console.WriteLine("El usuario " + nombreUsuario + " no existe.");
        return;
    }

    List<Mensaje> mensajes = usuario.UsuariosSeguidos.SelectMany(u => u.Mensajes).OrderBy(m => m.HoraDePublicacion).ToList();
    foreach (Mensaje mensaje in mensajes)
    {
    if (mensaje != null)
    {
        string contenido = mensaje.Contenido != null ? mensaje.Contenido : "Contenido no disponible";
        string nombreUsuarioMensaje = mensaje.Usuario != null && mensaje.Usuario.Nombre != null ? mensaje.Usuario.Nombre : "Usuario no disponible";
        string horaDePublicacion = mensaje.HoraDePublicacion != null ? mensaje.HoraDePublicacion.ToString("HH:mm") : "Hora de publicación no disponible";

        Console.WriteLine("\"" + contenido + "\" @" + nombreUsuarioMensaje + " @" + horaDePublicacion);
    }
    }
}


public void Load(string nombreArchivo)
{
    Console.WriteLine("Intentando cargar el archivo: " + nombreArchivo);

    if (!File.Exists(nombreArchivo))
    {
        throw new SystemException("No existe el archivo " + nombreArchivo);
    }

    Console.WriteLine("El archivo existe, leyendo las líneas...");

    string[] lineas = File.ReadAllLines(nombreArchivo);
    foreach (string linea in lineas)
    {
        Console.WriteLine("Procesando la línea: " + linea);

        string[] partes = linea.Split(' ');

        switch (partes[0].ToLower())
        {
            case "post":
                if (partes.Length >= 3 && partes[1].ToLower() == "#usuario")
                {
                    CrearUsuario(partes[2]);
                }
                else if (partes.Length >= 3)
                {
                    Post(partes[1].TrimStart('@'), string.Join(" ", partes.Skip(2)));
                }
                break;
            case "follow":
                if (partes.Length == 3)
                {
                    Follow(partes[1].TrimStart('@'), partes[2].TrimStart('@'));
                }
                break;
            case "dashboard":
                if (partes.Length == 2)
                {
                    Dashboard(partes[1].TrimStart('@'));
                }
                break;
            default:
                Console.WriteLine("Comando desconocido en el archivo.");
                break;
        }
    }

    Console.WriteLine("Se ha cargado con éxito el archivo " + nombreArchivo);
}







public void CrearUsuario(string nombreUsuario)
{
    // Comprueba si el usuario ya existe
    Usuario usuarioExistente = Aplicacion.Usuarios.Find(u => u.Nombre == nombreUsuario);
    if (usuarioExistente != null)
    {
        Console.WriteLine("El usuario " + nombreUsuario + " ya existe.");
        return;
    }

    // Crea un nuevo usuario
    Usuario nuevoUsuario = new Usuario(nombreUsuario);

    // Añade el nuevo usuario a la lista de usuarios de la aplicación
    Aplicacion.Usuarios.Add(nuevoUsuario);

    Console.WriteLine("Se ha creado el usuario " + nombreUsuario + ".");
}



}