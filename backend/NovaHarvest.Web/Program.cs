var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Content("""
    <!DOCTYPE html>
    <html lang="es">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>NovaHarvest</title>
    </head>
    <body>
        <h1>NovaHarvest</h1>
        <p>Bienvenido a NovaHarvest.</p>
        <p>Una plataforma para aprovechar los excedentes agrícolas del Valle del Jerte.</p>
    </body>
    </html>
    """, "text/html"));
    app.MapGet("/about", () => Results.Content("""
    <!DOCTYPE html>
    <html lang="es">
    <head>
        <meta charset="UTF-8">
        <title>Sobre NovaHarvest</title>
    </head>
    <body>
        <h1>Sobre NovaHarvest</h1>
        <p>Proyecto desarrollado en el IES Valle del Jerte.</p>
        <p>Autor: Raúl Albalat Pérez</p>
        <p>Versión: 0.1.0</p>
    </body>
    </html>
    """, "text/html"));
    app.MapGet("/status", () => Results.Content($"""
    <!DOCTYPE html>
    <html lang="es">
    <head>
        <meta charset="UTF-8">
        <title>Estado del servidor</title>
    </head>
    <body>
        <h1>Estado del servidor</h1>
        <p>Fecha y hora: {DateTime.Now:dd/MM/yyyy HH:mm:ss}</p>
        <p>Página generada por ASP.NET Core (Kestrel)</p>
    </body>
    </html>
    """, "text/html"));

app.Run();
