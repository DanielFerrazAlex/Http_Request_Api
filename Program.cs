using CEP_HTTP_REQUEST.Data;
using CEP_HTTP_REQUEST.DTO_s;
using CEP_HTTP_REQUEST.Scripts;
using CEP_HTTP_REQUEST.Services;
using CEP_HTTP_REQUEST.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<Context>();
builder.Services.AddSingleton<ICepService, CepService>();
builder.Services.AddSingleton<IExternalApiService, ExternalAPI>();
builder.Services.AddAutoMapper(typeof(ResponseEntity));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
