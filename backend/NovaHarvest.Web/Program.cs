var builder = WebApplication.CreateBuilder(args);

//añado los servicios de Razor Pages 
builder.Services.AddRazorPages();
var app = builder.Build();
app.MapStaticAssets();

// Configuro la localización española.
app.UseRequestLocalization("es-ES");

//Quito todo el html que tenia antiguo y lo digo a la aplicacion que use Razor PAges.
app.MapRazorPages();


app.Run();
