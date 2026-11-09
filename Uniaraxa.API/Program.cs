using Uniaraxa.Domain.Interfaces;
using Uniaraxa.Infra.Repositories;
using Uniaraxa.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Student
builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

// Teacher
builder.Services.AddSingleton<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
