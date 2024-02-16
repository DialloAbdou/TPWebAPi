using Microsoft.AspNetCore.Mvc;
using tpWebminiAPi.Todo;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSingleton<TodoService>();

var app = builder.Build();

app.MapGet("/todos/", (TodoService todoService) =>
{
   return Results.Ok(todoService.getAllToDo());
});

app.MapGet("todos/{id:int}", (
    [FromRoute] int id,
    [FromServices] TodoService todoService) =>
{
    var todo = todoService.GetTodoById(id);
    if (todo is not null)
    {
        return Results.Ok(todo);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapGet("/todos/active", ([FromServices] TodoService todoService) =>
{
    var todoActive = todoService.getAllToDo().Where(t => t.EndDate is null);

    if (todoActive is not null)
    {
        return Results.Ok(todoActive);
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapPost("todos", (
    [FromBody] string titre,
    [FromServices] TodoService todoService) =>
{
    return Results.Ok(todoService.AddToDo(titre));
});

app.MapDelete("todos/{id: int}", (
    [FromRoute] int id,
    [FromServices] TodoService todoService) =>
{
    var result = todoService.DeleteTodo(id);
    if (result)
    {
        return Results.NoContent();
    }
    else
    {
        return Results.NotFound(result);
    }
});

app.MapPut("todos/{id:int}",
    ([FromRoute] int id,
    [FromBody] Todo todo,
    [FromServices] TodoService todoService) =>
 {
     var todonew = todoService.Update(id, todo);

     return Results.Ok(todonew);
 });
app.Run();