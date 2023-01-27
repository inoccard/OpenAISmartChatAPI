using AutoMapper;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using OpenAI.GPT3.Extensions;
using OpenAI.SmartChat.API.Configs;
using OpenAI.SmartChat.API.Configs.SupportedCultures;
using OpenAI.SmartChat.API.Configs.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddVersionedSwagger();

builder.Services.AddCors();
builder.Services.AddOpenAIService();
builder.Services.RegisterComponents();
builder.Services.AddAutoMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSupportedCultures(builder.Configuration);

app.UseVersionedSwagger(app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

app.UseCors(a => a.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();