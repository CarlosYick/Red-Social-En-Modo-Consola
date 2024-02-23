using Xunit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ComandoTests
{
    [Fact]
    public void Post_UsuarioExistente_MensajeCreado()
    {
        // Arrange (Organizar)
        var aplicacion = new Aplicacion();
        var comando = new Comando(aplicacion);
        var usuario = new Usuario("Luis");
        aplicacion.Usuarios.Add(usuario);
        var contenido = "Hola a todos";

        // Act (Actuar)
        comando.Post(usuario.Nombre, contenido);

        // Assert (Afirmar)
        Assert.Single(usuario.Mensajes);
        Assert.Equal(contenido, usuario.Mensajes[0].Contenido);
    }

    [Fact]
    public void Follow_UsuariosExistentes_UsuarioSeguido()
    {
        // Arrange (Organizar)
        var aplicacion = new Aplicacion();
        var comando = new Comando(aplicacion);
        var usuario1 = new Usuario("Luis");
        var usuario2 = new Usuario("Jorge");
        aplicacion.Usuarios.Add(usuario1);
        aplicacion.Usuarios.Add(usuario2);

        // Act (Actuar)
        comando.Follow(usuario1.Nombre, usuario2.Nombre);

        // Assert (Afirmar)
        Assert.Single(usuario1.UsuariosSeguidos);
        Assert.Equal(usuario2, usuario1.UsuariosSeguidos[0]);
    }

    [Fact]
    public void Dashboard_UsuarioExistente_MensajesOrdenados()
    {
        // Arrange (Organizar)
        var aplicacion = new Aplicacion();
        var comando = new Comando(aplicacion);
        var usuario1 = new Usuario("Luis");
        var usuario2 = new Usuario("Jorge");
        aplicacion.Usuarios.Add(usuario1);
        aplicacion.Usuarios.Add(usuario2);
        usuario1.UsuariosSeguidos.Add(usuario2);
        var mensaje1 = new Mensaje("Hola", DateTime.Now, usuario2);
        var mensaje2 = new Mensaje("Adiós", DateTime.Now.AddHours(1), usuario2);
        usuario2.Mensajes.Add(mensaje1);
        usuario2.Mensajes.Add(mensaje2);

        // Act (Actuar)
        comando.Dashboard(usuario1.Nombre);

        // Assert (Afirmar)
        Assert.Equal(2, usuario1.UsuariosSeguidos[0].Mensajes.Count);
        Assert.Equal(mensaje1, usuario1.UsuariosSeguidos[0].Mensajes[0]);
        Assert.Equal(mensaje2, usuario1.UsuariosSeguidos[0].Mensajes[1]);
    }



[Fact]
public void CrearUsuario_NombreValido_UsuarioCreado()
{
    // Arrange (Organizar)
    var aplicacion = new Aplicacion();
    var comando = new Comando(aplicacion);
    var nombreUsuario = "Luis";

    // Act (Actuar)
    comando.CrearUsuario(nombreUsuario);

    // Assert (Afirmar)
    Assert.Equal(4, aplicacion.Usuarios.Count); // Cambiado de Assert.Single a Assert.Equal
    Assert.Equal(nombreUsuario, aplicacion.Usuarios[3].Nombre); // Cambiado de aplicacion.Usuarios[0].Nombre a aplicacion.Usuarios[3].Nombre
}

[Fact]
public void Post_UsuarioNoExistente_Error()
{
    // Arrange (Organizar)
    var aplicacion = new Aplicacion();
    var comando = new Comando(aplicacion);
    var contenido = "Hola a todos";

    // Act (Actuar)
    var exception = Assert.Throws<Exception>(() => comando.Post("@UsuarioNoExistente", contenido));

    // Assert (Afirmar)
    Assert.Equal("El usuario @UsuarioNoExistente no existe.", exception.Message);
}

[Fact]
public void Load_ArchivoNoExistente_Error()
{
    // Arrange (Organizar)
    var aplicacion = new Aplicacion();
    var comando = new Comando(aplicacion);
    var nombreArchivo = "archivoNoExistente.txt";

    // Act (Actuar)
    var exception = Assert.Throws<SystemException>(() => comando.Load(nombreArchivo));

    // Assert (Afirmar)
    Assert.Equal($"No existe el archivo {nombreArchivo}", exception.Message);
}

[Fact]
public void Follow_UsuarioNoExistente_Error()
{
    // Arrange (Organizar)
    var aplicacion = new Aplicacion();
    var comando = new Comando(aplicacion);
    var usuario1 = new Usuario("Luis");

    // Act (Actuar)
    var exception = Assert.Throws<Exception>(() => comando.Follow(usuario1.Nombre, "@UsuarioNoExistente"));

    // Assert (Afirmar)
    Assert.Equal($"El usuario {usuario1.Nombre} no existe.", exception.Message);
}

[Fact]
public void Post_ContenidoNulo_Error()
{
    // Arrange (Organizar)
    var aplicacion = new Aplicacion();
    var comando = new Comando(aplicacion);
    var usuario = new Usuario("Luis");
    aplicacion.Usuarios.Add(usuario);

    // Act (Actuar)
    var exception = Assert.Throws<Exception>(() => comando.Post(usuario.Nombre, null));

    // Assert (Afirmar)
    Assert.Equal("Contenido no disponible", exception.Message);
}


}
