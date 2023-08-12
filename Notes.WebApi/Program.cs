using Notes.Application.Common.Mappings;
using Notes.Application.Dependencies;
using Notes.Persistense.DatabaseContext;
using Notes.Persistense.DatabaseControls;
using Notes.Persistense.Dependencies;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<NotesDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex) { }
}

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
});

builder.Services.AddAplication();
builder.Services.AddPersistence(app.Configuration);



app.Run();
