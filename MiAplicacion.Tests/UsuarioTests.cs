using Xunit;
using System.Linq;

public class UsuarioTests
{
    [Fact]
    public void CrearUsuario_NombreValido_UsuarioCreado()
    {
        // Arrange (Organizar)
        var nombre = "Luis";

        // Act (Actuar)
        var usuario = new Usuario(nombre);

        // Assert (Afirmar)
        Assert.NotNull(usuario);
        Assert.Equal(nombre, usuario.Nombre);
    }

    [Fact]
    public void Usuario_Inicializado_ListasNoNulas()
    {
        // Arrange (Organizar)
        var nombre = "Luis";

        // Act (Actuar)
        var usuario = new Usuario(nombre);

        // Assert (Afirmar)
        Assert.NotNull(usuario.Mensajes);
        Assert.NotNull(usuario.UsuariosSeguidos);
    }

    [Fact]
    public void Usuario_Inicializado_ListasVacias()
    {
        // Arrange (Organizar)
        var nombre = "Luis";

        // Act (Actuar)
        var usuario = new Usuario(nombre);

        // Assert (Afirmar)
        Assert.Empty(usuario.Mensajes);
        Assert.Empty(usuario.UsuariosSeguidos);
    }

    [Fact]
public void Usuario_AgregarMensaje_ListaActualizada()
{
    
    // Arrange (Organizar)
    var nombre = "Luis";
    var usuario = new Usuario(nombre);
    var horaDePublicacion = DateTime.Now;
    var mensaje = new Mensaje("Hola mundo",horaDePublicacion, usuario);

    // Act (Actuar)
    usuario.Mensajes.Add(mensaje);

    // Assert (Afirmar)
    Assert.Single(usuario.Mensajes);
    Assert.Contains(mensaje, usuario.Mensajes);
}

[Fact]
public void Usuario_SeguirUsuario_ListaActualizada()
{
    // Arrange (Organizar)
    var nombre1 = "Luis";
    var usuario1 = new Usuario(nombre1);
    var nombre2 = "Maria";
    var usuario2 = new Usuario(nombre2);

    // Act (Actuar)
    usuario1.UsuariosSeguidos.Add(usuario2);

    // Assert (Afirmar)
    Assert.Single(usuario1.UsuariosSeguidos);
    Assert.Contains(usuario2, usuario1.UsuariosSeguidos);
}

}