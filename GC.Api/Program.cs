using GC.Core.Services.Implementation;
using GC.Core.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//INYECCION DE DEPENDENCIA
builder.Services.AddTransient<IProyectosService, ProyectosService>();
builder.Services.AddTransient<IUsuariosService, UsuariosService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.ASCII.GetBytes("Pl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlosPl@t1n1umcarlos")),
        ValidateIssuer = false,
        ValidateAudience = false,

    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<SecurityRequirementsOperationFilter>();
    c.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description="Autorizacion Standard,Usar Bearer. Ejemplo \"bearer {token}\"",
        In=ParameterLocation.Header,
        Name="Authorization",
        Type=SecuritySchemeType.ApiKey,
        Scheme="Bearer"
    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services cors
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
