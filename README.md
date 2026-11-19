 SISTEMA DE CARTELERA DE CINE
 Descripción del proyecto:
 Este proyecto consiste en un sistema de consola desarrollado en C# para administrar las funciones de la cartelera de un cine. Permite registrar peliculas, consultar las funciones disponibles, buscar registros por su ID, actualizar precios y eliminar funciones.
La información se almacena en una base de datos SQL Server LocalDB, utilizando consultas parametrizadas para trabajar con los datos.

REQUISITOS:
. Visual Studio Community 2026
. SQL Server LocalDB.
. .NET Compatible con el proyecto.
. Los archivos del proyecto y el script SQL.

COMO SE EJECUTA EL PROYECTO:
1. Abrir el archivo de solución del proyecto en Visual Studio.
2. Abrir el script. 01_crear_CarteleraDB.sql y ejecutarlo en SQL Server para crear la base de datos y sus registros iniciales.
3. Verificar que la cadena de conexión del proyecto corresponda a la instancia de SQL Server LocalDB utilizada.
4. Ejecutar el programa desde Visual Studio utilizando F5 o Ctrl + F5 .
5. Utilizar las opciones del menu para registrar, listar, buscar, actualizar o eliminar funciones.
   
FUNCIONES DEL SISTEMA:
.   Registrar nuevas funciones de peliculas.
. Mostrar las funciones registradas y el total de precios.
. Buscar una función por su ID.
. Actualizar el precio de una funcion.
. Eliminar una función.
. Validar los datos ingresados y controlar errores de conexión con la base de datos.

CAPTURAS DE FUNCIONAMIENTO:
En la carpeta Capturas se incluyen las evidencias de las pruebas realizadas al sistema:
1. Registro y listado de funciones.
2. Actualizacion y eliminacion de funciones.
3. Validación de datos incorrectos
4. Manejo de errores de conexión con las base de datos.

ARCHIVOS DEL PROYECTO:
. Funcion.cs: Contiene la clase que representa una función de cine. 
. FuncionRepositorio.cs: Contiene los métodos para trabajar con la base de datos.
. Program.cs: Contiene el menú principal y las opciones del sistema.
.01_crear_CarteleraDB.sql: Contiene el script para crear la base de datos.
