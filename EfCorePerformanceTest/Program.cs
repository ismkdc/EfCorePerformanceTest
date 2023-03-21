using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Persons;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<Context>(options =>
{
    options.UseNpgsql("Host=localhost;Username=usr;Password=passwd;Database=db",
            npgsqlOptions =>
            {
                npgsqlOptions.ExecutionStrategy(d => new NonRetryingExecutionStrategy(d));
            })
        .EnableThreadSafetyChecks(false);
});

var app = builder.Build();

for (int i = 0; i < 1024; i++)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<Context>();

    db.Persons.FirstOrDefaultAsync();
}

app.MapGet("/read", async (Context context) => EfDb.Read(context));

app.MapPost("/insert", async (Context context) =>
{
    context.Persons.Add(new Person { name = "Ali", surname = "Veli" });
    await context.SaveChangesAsync();
});



app.Run();