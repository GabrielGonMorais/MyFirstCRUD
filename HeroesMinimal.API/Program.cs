using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region [Cors]
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});
#endregion

app.UseHttpsRedirection(); 

#region [endpoints]
app.MapGet("/Hero/{id}", async (DataContext context, int id) =>
    await context.SuperHeroes.Include(e => e.Comic).SingleOrDefaultAsync(e => e.ID == id) is SuperHero hero ?
    Results.Ok(hero) :
    Results.BadRequest("Hero not found"));


app.MapGet("/Heroes", async (DataContext context) =>
    await context.SuperHeroes.Include(e => e.Comic).ToListAsync());

app.MapGet("/Comics", async (DataContext context) =>
    await context.Comics.ToListAsync());


app.MapPost("/Hero", async (DataContext context, SuperHero hero) =>
{
    await context.SuperHeroes.AddAsync(hero);
    await context.SaveChangesAsync();
    return Results.Ok();
});

app.MapDelete("/Hero/{id}", async (DataContext context, int id) =>
{
    var hero = await context.SuperHeroes.FindAsync(id);
    if (hero == null)
        return Results.BadRequest("Hero not found");

    context.SuperHeroes.Remove(hero);
    await context.SaveChangesAsync();
    return Results.Ok();
});


app.MapPut("/Hero/{id}", async (DataContext context, SuperHero request) =>
{
    var dbHero = await context.SuperHeroes.FindAsync(request.ID);
    if (request == null)
        return Results.BadRequest("Hero not found");

    dbHero.HeroName = request.HeroName;
    dbHero.AlterEgo = request.AlterEgo;
    dbHero.ComicID = request.ComicID;
    await context.SaveChangesAsync();

    return Results.Ok();
});
#endregion

app.Run();

