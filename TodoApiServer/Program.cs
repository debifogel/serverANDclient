using Microsoft.AspNetCore.Mvc;
using TodoApiServer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin() // Allow all origins
               .AllowAnyMethod() // Allow any HTTP method
               .AllowAnyHeader(); // Allow any header
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ToDoDB"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ToDoDB"))));
var app = builder.Build();
app.UseCors("AllowAllOrigins");

app.MapGet("/item", async(ToDoDbContext _service) => await Task.FromResult(_service.Items));
app.MapPost("/item", async ([FromBody] string task, ToDoDbContext _service) =>
{
    _service.Items.Add(new Item() { Name = task, IsComplete = false });
   var i= await _service.SaveChangesAsync();
    return Results.Ok(i);
});
app.MapPut("/item/{taskId}", async (int taskId, [FromBody] bool IsComplete, ToDoDbContext _service) =>
{
    var i = await _service.Items.FindAsync(taskId);
    if (i != null)
    {
        i.IsComplete = IsComplete;
        await _service.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});
app.MapDelete("/item/{taskId}", async(int taskId, ToDoDbContext _service) =>
{
    var i = await _service.Items.FindAsync(taskId);
    if (i != null)
  {  _service.Items.Remove(i);
        await _service.SaveChangesAsync();
        return Results.Ok();
  }
  return Results.NotFound();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
options => // יוצר את הממשק של Swagger UI
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        options.RoutePrefix = string.Empty; // מציג את Swagger ב-root של האפליקציה
    });
    
}
app.Run();
