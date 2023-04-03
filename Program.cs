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

app.Run();
