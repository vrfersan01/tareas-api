# Tareas API
API REST en ASP.NET Core con persistencia en MySQL usando Entity Framework Core.
## Tecnologias
- C# / .NET 8 / ASP.NET Core Web API
- Entity Framework Core (proveedor Pomelo para MySQL)
- MySQL
## Como ejecutarlo
1. Crear la base de datos vacia en MySQL: CREATE DATABASE tareas_api;
2. Poner tu cadena de conexion en appsettings.json.
3. Aplicar las migraciones: Update-Database (Consola del Admin. de paquetes).
4. Ejecutar con Ctrl+F5; se abre Swagger.