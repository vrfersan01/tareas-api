# Tareas API
API REST en ASP.NET Core para gestionar tareas. Version web del Gestor de
Tareas, primer proyecto del Mes 2.
## Endpoints
- GET /api/tareas Lista todas las tareas
- GET /api/tareas/{id} Obtiene una tarea
- POST /api/tareas Crea una tarea
- PUT /api/tareas/{id} Actualiza una tarea
- DELETE /api/tareas/{id} Borra una tarea
## Tecnologias
- C# / .NET 8 / ASP.NET Core Web API
- Documentacion con Swagger
## Como ejecutarlo
1. Abrir la solucion en Visual Studio.
2. Ejecutar con Ctrl+F5; se abre Swagger en el navegador.
Nota: los datos se guardan en memoria y se reinician al parar la app.
En la siguiente version se conectara a MySQL con Entity Framework.