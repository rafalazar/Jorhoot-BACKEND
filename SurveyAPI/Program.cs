using Microsoft.EntityFrameworkCore;
using SurveyAPI.Models;
using SurveyAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ISurveyService, SurveyService>();
builder.Services.AddDbContext<EfDataContext>(d =>
    d.UseNpgsql(builder.Configuration.GetConnectionString("Ef_Postgres_Db")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(policyBuilder => 
    policyBuilder.AddDefaultPolicy( policy => 
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()
        ));

var app = builder.Build();

app.UseCors();

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
