using LibraryApi.Contracts;
using LibraryApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyectamos la clase AuthorRepository Mock, SQL o la que proceda.
//Se crea una instancia de la clase authorRepository cada vez que se requiere una peticion, cada request. 
//builder.Services.AddTransient<IAuthorRepository, AuthorRepositoryMock>();
builder.Services.AddTransient<IAuthorRepository, AuthorRepositorySQL>();
//Se crea una instancia para todo. Si vas a levantar un LOG de sistema está bien, se queda abierta. Pero para peticiones de request no sirve
//builder.Services.AddSingleton<IAuthorRepository, AuthorRepositoryMock>();
//Crea una instacia por metodo GET, POST. Con lo que solo tenemos una instancia por metodo
//builder.Services.AddScoped<IAuthorRepository, AuthorRepositoryMock>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
