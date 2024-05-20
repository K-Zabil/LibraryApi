using UserWebApi.Api;
using UserWebApi.Repositories;
using UserWebApi.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserMsSqlRepository, UserMsSqlRepository>();
builder.Services.AddScoped<BookApi>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();

app.Run();