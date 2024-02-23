## Descripción ##

Red social en modo consola (similar a Twitter).

FUNCIONAMIENTO:

Usuarios:
  Se debe de poder crear usuarios.
● Por defecto existirán 3 usuarios ya creados, @Pedro, @Jorge, @Fernanda.
● Para crear nuevos usuarios se utilizará el siguiente comando
  o post #Usuario Luis
● Donde:
  o post: es la acción
  o #Usuario: indica que será una creación de usuario
  o Luis: es el nombre del usuario, no se aceptan espacios en blanco en el nombre.
● Si el usuario ya existe debe de indicar que ya existe y no se creara uno nuevo.

Publicación de mensajes:
  Cada usuario debe de poder publicar mensajes en su muro, de manera que estos puedan ser
  visualizados más adelante.
  ● La forma de crear mensajes será la siguiente:
    o post @Luis Hola a todos
  ● Donde:
    o post: es el comando a utilizar
    o @Luis: es el usuario que lo publicara
    o Hola a todos: es el mensaje que se publicara en el muro de Luis.
  ● El sistema deberá de mostrar como resultado lo siguiente
    o Luis posted -&gt; “Hola a todos” @10:30
  ● Otro ejemplo:
    o post @Jorge me siento feliz
  ● Resultado:
    o Jorge posted -&gt; “me siento feliz” @17:20

Follow:
  Cada usuario tiene la posibilidad de seguir a los usuarios existentes que desee.
  ● La forma en que se realizar es la siguiente:
    o Follow @Luis @Jorge
  ● Donde:
    o follow: indica la acción de seguir
    o @Luis: es el usuario que va a realizar la acción de seguir  
    o @Jorge: es el usuario al cual Luis va a seguir.
  ● El resultado de este comando deberá de ser el siguiente:
    o “Luis empezó a seguir a Jorge”
  ● Si no existe alguno de los dos usuarios deberá de indicarlo:
    o “El usuario Luis no existe”
    o “El usuario Jorge no existe”
  ● Si Luis ya sigue a Jorge y vuelve a ejecutar la acción deberá mostrar lo siguiente:
    o “@Luis ya esta siguiendo a @Jorge”

Dashboard:
  El dashboard es el muro donde cada usuario podrá visualizar el propio, por lo tanto, podrá ver publicaciones hechas por los usuarios a los que sigue, ordenados por hora.
  ● El comando es el siguiente:
    o dashboard @Luis
  ● Donde:
    o dashboard: es la acción a realizar
    o @Luis: es el usuario que quiere ver su muro
  ● El resultado es el siguiente:
    o “Hoy puede ser un gran dia” @Ivan @08:10
    o “Hola mundo” @Alfonso @10:30
    o “Para casa ya, media jornada, 12h” @Ivan @20:10
    o “Adiós mundo cruel” @Alfonso @20:30

Carga de archivo:
  Se debe permitir cargar un archivo con comandos ya definidos, cada comando se realizará
  línea por línea.
  ● El comando a utilizar es el siguiente:
    o load “C:\archivo.txt”
  ● Donde:
    o load: indica que se cargara el archivo
    o “C:\archivo.txt”: indica el path a utilizar para cargar el archivo.
  ● Resultado:
    o “Se ha cargado con éxito el archivo archivo.txt”
  ● Si hubiera un problema con el archivo deberá mostrarlo:
    o “No existe el archivo archivo.txt”
    o “El archivo.txt está bloqueado”

## Autor ##
**Carlos Alberto Yick Castillo**

* [LinkedIn](https://www.linkedin.com/in/carlosyick/)

## Contratación ##
Si quieres contratarme puedes escribirme a carlosyick@gmail.com para consultas.
