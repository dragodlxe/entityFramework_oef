using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oefproject;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TasksContext>(p => p.UseInMemoryDatabase("TasksDB"));
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("TasksDB"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconnection", async([FromServices] TasksContext DbContext) => 
{
    DbContext.Database.EnsureCreated();
    return Results.Ok("DB on memory " + DbContext.Database.IsInMemory());
});
app.MapGet("/api/Tasks", async([FromServices] TasksContext DbContext)=> 
{
    return Results.Ok(DbContext.Tasks.Include(p => p.Category));
});
app.MapPost("/api/Tasks", async([FromServices] TasksContext DbContext, [FromBody] oefproject.models.Task task)=> 
{
    task.TaskId = Guid.NewGuid();
    task.CreateDt = DateTime.Now;
    await  DbContext.AddAsync(task);
    //await DbContext.Tasks.AddAsync(task); 

    await DbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/Tasks/{id}", async([FromServices] TasksContext DbContext, [FromBody] oefproject.models.Task task, [FromRoute] Guid id)=> 
{
    var CurrentTask =  DbContext.Tasks.Find(id);

    if(CurrentTask != null)
    {
        CurrentTask.CategoryId = task.CategoryId;
        CurrentTask.Title = task.Title; 
        CurrentTask.TaskPriority = task.TaskPriority;
        CurrentTask.Description = task.Description;
        await DbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();

});

app.MapDelete("/api/Tasks/{id}", async([FromServices] TasksContext DbContext, [FromRoute] Guid id) =>
{
    var CurrentTask =  DbContext.Tasks.Find(id);
    if(CurrentTask != null)
    {
        DbContext.Remove(CurrentTask);
        await DbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
    
});

app.Run();
