using PokeBL;
using PokeDL;
using PokeModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Environment.GetEnvironmentVariable("Connection_String")
//builder.Configuration.GetConnectionString("Stephen_Pagdilao_DbDemo")

builder.Services.AddScoped<IRepository<Pokemon>, SQLPokemonRepository>(repo => new SQLPokemonRepository(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<IPokemonBL, PokemonBL>();
builder.Services.AddScoped<IRepository<PokemonAbilityJoin>, SQLPokeAbilityJoinRepo>(repo => new SQLPokeAbilityJoinRepo(Environment.GetEnvironmentVariable("Connection_String")));
builder.Services.AddScoped<IPokeAbiJoinBL, PokeAbiJoinBL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//Some comment