using tpWebminiAPi.Todo;

var builder = WebApplication.CreateBuilder();
builder.Services.AddSingleton<TodoService>();
var app = builder.Build();
app.MapGet("/hello", () => "hello Abdou");
app.MapGet("/todos/1", () => new Todo { Id = 1, Titre = "formation Api", StartDate = DateTime.Today });
app.MapGet("/todos/", ( TodoService todoService) =>
{
     var todos= todoService.getAllToDo();
      return Results.Ok(todos);
});
app.MapGet("/todos/{id:int}",(int id, TodoService todoService)=>{
    var todo = todoService.getAllToDo().Find(t => t.Id == id);
    if(todo is not null)
    {
        return Results.Ok(todo);
    }else
    {
        return Results.NotFound();
    }
});

app.MapGet("/todos/active", (TodoService todoService) =>
{
    var todoActive = todoService.getAllToDo().Where(t=>t.EndDate is null);

    if(todoActive is not null)
    {
        return Results.Ok(todoActive);
    }else
    {
        return Results.NotFound();
    }
});
app.Run();