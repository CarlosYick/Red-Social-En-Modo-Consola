using Xunit;
using System;

public class MensajeTests
{
    [Fact]
    public void CrearMensaje_DatosValidos_MensajeCreado()
    {
        // Arrange (Organizar)
        var contenido = "Hola a todos";
        var horaDePublicacion = DateTime.Now;
        var usuario = new Usuario("Luis");

        // Act (Actuar)
        var mensaje = new Mensaje(contenido, horaDePublicacion, usuario);

        // Assert (Afirmar)
        Assert.NotNull(mensaje);
        Assert.Equal(contenido, mensaje.Contenido);
        Assert.Equal(horaDePublicacion, mensaje.HoraDePublicacion);
        Assert.Equal(usuario, mensaje.Usuario);
    }

    [Fact]
public void Mensaje_CambiarContenido_ContenidoActualizado()
{
    // Arrange (Organizar)
    var contenido = "Hola a todos";
    var horaDePublicacion = DateTime.Now;
    var usuario = new Usuario("Luis");
    var mensaje = new Mensaje(contenido, horaDePublicacion, usuario);

    // Act (Actuar)
    var nuevoContenido = "Hola mundo";
    mensaje.Contenido = nuevoContenido;

    // Assert (Afirmar)
    Assert.Equal(nuevoContenido, mensaje.Contenido);
}

[Fact]
public void Mensaje_CambiarHoraDePublicacion_HoraDePublicacionActualizada()
{
    // Arrange (Organizar)
    var contenido = "Hola a todos";
    var horaDePublicacion = DateTime.Now;
    var usuario = new Usuario("Luis");
    var mensaje = new Mensaje(contenido, horaDePublicacion, usuario);

    // Act (Actuar)
    var nuevaHoraDePublicacion = DateTime.Now.AddHours(1);
    mensaje.HoraDePublicacion = nuevaHoraDePublicacion;

    // Assert (Afirmar)
    Assert.Equal(nuevaHoraDePublicacion, mensaje.HoraDePublicacion);
}

[Fact]
public void Mensaje_CambiarUsuario_UsuarioActualizado()
{
    // Arrange (Organizar)
    var contenido = "Hola a todos";
    var horaDePublicacion = DateTime.Now;
    var usuario = new Usuario("Luis");
    var mensaje = new Mensaje(contenido, horaDePublicacion, usuario);

    // Act (Actuar)
    var nuevoUsuario = new Usuario("Maria");
    mensaje.Usuario = nuevoUsuario;

    // Assert (Afirmar)
    Assert.Equal(nuevoUsuario, mensaje.Usuario);
}

}
