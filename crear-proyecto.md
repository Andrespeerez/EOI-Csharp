# crear proyecto
dotnet new mvc --language 'C#' --name 'DemoMVC' --framework 'NET7.0' --output .

# cargar nuevas dependencias y librerias
# lee el archico .csproj para comprobar dependencias y más cosas
dotnet restore

# compilar
dotnet build

# ejecutar
dotnet run

# añadir paquete (instala desde repositorio NuGet.org)
dotnet add package Microsoft.EntityFrameworkCore

# instalar paquete:
dotnet install package ...


# http://localhost:5114

######################
# crear una solucion #
######################
  1- Creamos una carpeta nueva para la solucion

 # para iniciar la solucion:
  2- dotnet new sln --name DemoSLN --output .

 # para listar los proyectos:
  3- dotnet sln list

 # Crear proyectos dentro de la solucion:
  4- dotnet new console -lang "C#" -n "ConsoleApp1" --o ./ConsoleApp1/
  5- dotnet new mvc -lang "C#" -n "WebApp1" -o ./WebApp1/
  
 # asociar los proyectos a la solucion SLN:
  6- dotnet sln add ./ConsoleApp1
  7- dotnet sln add ./WebApp1

 # para listar los proyectos:
  8- dotnet sln list

 # Eliminar un proyecto de la solucion:
 # esta tarea no suele hacerse habitualmente
  9- dotnet sln remove WebApp1

##############
Ejercicio
##############
# Creamos una solucion llamada Morfeus Solution
# Creamos un proyecto de consolla llamado ConsolaTest1
# Creamos un proyecto Web MVC llamado WebApp-Frontend1
# Creamos una libreria de clases llamada Morfeus.Core
# Añadimos todos los proyectos a la solucion

$:  mkdir MorfeusSol
$:  cd MorfeusSol
$:  dotnet new sln -n "Morfeus Solution" -o .
$:  dotnet new console -n "ConsolaTest1" -o ./ConsolaTest1
$:  dotnet new mvs -n "WebApp-Frontend1" -o ./WebAppFrontend1
$:  dotnet new classlib -n "Morfeust.Core" -o ./MorfeusCore
$:  dotnet sln add ./ConsolaTest1
$:  dotnet sln add ./WebAppFrontend1
$:  dotnet sln add ./MorfeusCore

###############################################
Estructura de espacio de nombres para proyectos
###############################################
    Morfeus.Core
    Morfeus.Web.Frontend
    Morfeus.Api
    Morfeus.Mobile.App.Admin
    Morfeus.Mobile.App.Customer

Cada proyecto tendrá sus clases correspondientes. Si necesitamos acceder a una clase dentro de Morfeus.Core sería, Morfeus.Core.Customers, etc.


