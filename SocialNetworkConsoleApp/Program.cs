class Program
{
    static void Main(string[] args)
    {
        // Crear una nueva instancia de la clase Aplicacion
        Aplicacion aplicacion = new Aplicacion();

        // Crear una nueva instancia de la clase Comando y pasarle la aplicación
        Comando comando = new Comando(aplicacion);

        // Crear los usuarios predeterminados
        aplicacion.Usuarios.Add(new Usuario("Pedro"));
        aplicacion.Usuarios.Add(new Usuario("Jorge"));
        aplicacion.Usuarios.Add(new Usuario("Fernanda"));

        // Entrar en un bucle infinito para leer comandos del usuario
        while (true)
        {
            Console.Write("> ");
            string linea = Console.ReadLine();
            string[] partes = linea.Split(' ');

            // Ejecutar el comando correspondiente
            switch (partes[0].ToLower())
            {
                case "post":
                if (partes.Length >= 3)
                {
                    if (partes[1].ToLower() == "#usuario")
                    {
                        // Crear un nuevo usuario
                        comando.CrearUsuario(partes[2]);
                    }
                    else
                    {
                        // Publicar un mensaje
                        comando.Post(partes[1].TrimStart('@'), string.Join(" ", partes.Skip(2)));
                    }
                }
                break;
                case "follow":
                    if (partes.Length == 3)
                    {
                        comando.Follow(partes[1].TrimStart('@'), partes[2].TrimStart('@'));
                    }
                    break;
                case "dashboard":
                    if (partes.Length == 2)
                    {
                        comando.Dashboard(partes[1].TrimStart('@'));
                    }
                    break;
                case "load":
                    if (partes.Length >= 2)
                    {
                        // Unir todas las partes de la ruta del archivo
                        string nombreArchivo = string.Join(" ", partes.Skip(1)).Trim('"');

                        // Llamar al método Load
                        comando.Load(nombreArchivo);
                    }
                    break;
                default:
                    Console.WriteLine("Comando desconocido.");
                    break;
            }
        }
    }
}

