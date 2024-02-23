using Xunit;
using System.Linq;

public class AplicacionTests
{
    [Fact]
    public void CrearAplicacion_UsuariosIniciales_UsuariosCreados()
    {
        // Act (Actuar)
        var aplicacion = new Aplicacion();

        // Assert (Afirmar)
        Assert.NotNull(aplicacion.Usuarios);
        Assert.Equal(3, aplicacion.Usuarios.Count);
        Assert.Equal("@Pedro", aplicacion.Usuarios[0].Nombre);
        Assert.Equal("@Jorge", aplicacion.Usuarios[1].Nombre);
        Assert.Equal("@Fernanda", aplicacion.Usuarios[2].Nombre);
    }

    [Fact]
public void Aplicacion_AgregarUsuario_ListaActualizada()
{
    // Arrange (Organizar)
    var aplicacion = new Aplicacion();
    var usuario = new Usuario("@Carlos");

    // Act (Actuar)
    aplicacion.Usuarios.Add(usuario);

    // Assert (Afirmar)
    Assert.Equal(4, aplicacion.Usuarios.Count);
    Assert.Contains(usuario, aplicacion.Usuarios);
}

[Fact]
public void Aplicacion_EliminarUsuario_ListaActualizada()
{
    // Arrange (Organizar)
    var aplicacion = new Aplicacion();
    var usuario = aplicacion.Usuarios.First();

    // Act (Actuar)
    aplicacion.Usuarios.Remove(usuario);

    // Assert (Afirmar)
    Assert.Equal(2, aplicacion.Usuarios.Count);
    Assert.DoesNotContain(usuario, aplicacion.Usuarios);
}

}
