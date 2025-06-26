using examenBack.Controllers.Data;
using examenBack.Controllers.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WebinarDBContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("WebinarDB");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins(
                "*"
                )
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.MapGet("api/movie", async(WebinarDBContext context) =>
{
    var response = await context.Set<Movie>()
   .AsNoTracking()
   .ToListAsync();

    return Results.Ok(response);
});

app.MapGet("api/movie/{id:int}", async (int id, WebinarDBContext context) =>
{
    var response = await context.Set<Movie>()
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.id == id);
    if (response is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(response);
});

app.MapPost("api/movie", async (Movie movie, WebinarDBContext context) =>
{
    context.Set<Movie>().Add(movie);
    await context.SaveChangesAsync();
    return Results.Created($"/api/movies/{movie.id}", movie);
});

app.MapPut("api/movie/{id:int}", async (int id, Movie movie, WebinarDBContext context) =>
{
    if (id != movie.id)
    {
        return Results.BadRequest();
    }
    context.Entry(movie).State = EntityState.Modified;
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("api/movie/{id:int}", async (int id, WebinarDBContext context) =>
{
    var movie = await context.Set<Movie>().FindAsync(id);
    if (movie is null)
    {
        return Results.NotFound();
    }
    context.Set<Movie>().Remove(movie);
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.MapGet("api/director", async (WebinarDBContext context) =>
{
    var response = await context.Set<Director>()
   .AsNoTracking()
   .ToListAsync();

    return Results.Ok(response);
});

app.MapGet("api/director/{id:int}", async (int id, WebinarDBContext context) =>
{
    var response = await context.Set<Director>()
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.id == id);
    if (response is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(response);
});

app.MapPost("api/director", async (Director director, WebinarDBContext context) =>
{
    context.Set<Director>().Add(director);
    await context.SaveChangesAsync();
    return Results.Created($"/api/directors/{director.id}", director);
});

app.MapPut("api/director/{id:int}", async (int id, Director director, WebinarDBContext context) =>
{
    if (id != director.id)
    {
        return Results.BadRequest();
    }
    context.Entry(director).State = EntityState.Modified;
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("api/director/{id:int}", async (int id, WebinarDBContext context) =>
{
    var director = await context.Set<Director>().FindAsync(id);
    if (director is null)
    {
        return Results.NotFound();
    }
    context.Set<Director>().Remove(director);
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
