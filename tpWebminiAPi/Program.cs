using tpWebminiAPi.Todo;

var builder = WebApplication.CreateBuilder();

var app = builder.Build();
app.MapGet("/hello", () => "hello Abdou");
app.MapGet("/todo/1", () => new Todo { Id = 1, Titre = "formation Api", StartDate = DateTime.Today });

app.Run();