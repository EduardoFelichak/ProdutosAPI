
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProdutosAPI.Data;
using ProdutosAPI.Repositories;
using ProdutosAPI.Repositories.Abstract;
using ProdutosAPI.Services;
using ProdutosAPI.Services.Abstract;
using ProdutosAPI.Utils;

namespace ProdutosAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ConnectionContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5433;Database=ProdutosDB;Username=root;Password=root"));

            builder.Services.AddScoped<IUsuarioRepo, UsuarioRepo>();
            builder.Services.AddScoped<IUsuarioServ, UsuarioServ>();
            builder.Services.AddScoped<IProdutoRepo, ProdutoRepo>();
            builder.Services.AddScoped<IProdutoServ, ProdutoServ>();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProdutosAPI", Version = "v1" });

                // Definir os headers de autenticação customizados
                c.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "X-User-Email", // primeiro header
                    In = ParameterLocation.Header,
                    Description = "Email do usuário"
                });

                c.AddSecurityDefinition("basicAuthSenha", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "X-User-Senha", // segundo header
                    In = ParameterLocation.Header,
                    Description = "Senha do usuário"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
                            }, new string[] {}
                        },
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuthSenha" }
                            }, new string[] {}
                        }
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
