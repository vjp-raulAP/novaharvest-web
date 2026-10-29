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
app.Run();
