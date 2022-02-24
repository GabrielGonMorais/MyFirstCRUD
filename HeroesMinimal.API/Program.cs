using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/Hero/{id}", async (DataContext context, int id) =>
    await context.SuperHeroes.FindAsync(id) is SuperHero hero ?
    Results.Ok(hero) :
    Results.BadRequest("Hero not found"));


app.MapGet("/Heroes", async (DataContext context) =>
    await context.SuperHeroes.ToListAsync());


app.MapPost("/PostHero", async (DataContext context, SuperHero hero) =>
{
    await context.SuperHeroes.AddAsync(hero);
    await context.SaveChangesAsync();
    return Results.Ok();
});

app.MapDelete("/DeleteHero/{id}", async (DataContext context, int id) =>
{
    var hero = await context.SuperHeroes.FindAsync(id);
    if (hero == null)
        return Results.BadRequest("Hero not found");

    context.SuperHeroes.Remove(hero);
    await context.SaveChangesAsync();
    return Results.Ok();
});


app.MapPut("/PutHero/{id}", async (DataContext context, SuperHero request) =>
{
    var dbHero = await context.SuperHeroes.FindAsync(request.ID);
    if (request == null)
        return Results.BadRequest("Hero not found");

    dbHero.Nick = request.Nick;
    dbHero.LastName = request.LastName;
    dbHero.FirstName = request.FirstName;
    await context.SaveChangesAsync();

    return Results.Ok();
});

app.Run();
