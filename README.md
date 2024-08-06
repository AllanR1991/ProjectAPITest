# ProjectAPITest

## Documentação de Criação de API com ASP.NET Core
Este README orienta sobre a criação de uma API com ASP.NET Core, incluindo o projeto, pacotes, estrutura de pastas, configuração de contexto e configuração do Swagger.

## Índice

1. [Criando um Projeto ASP.NET Core Vazio](#criando-um-projeto-aspnet-core-vazio)
2. [Instalando Pacotes do Framework](#instalando-pacotes-do-framework)
3. [Criando a Estrutura de Pastas e Classes](#criando-a-estrutura-de-pastas-e-classes)
   - [Criando a Pasta `Domain`](#criando-a-pasta-domain)
   - [Criando a Pasta `Interface`](#criando-a-pasta-interface)
   - [Criando o Contexto do Banco de Dados](#criando-o-contexto-do-banco-de-dados)
5. [Configurando o Program.cs](#configurando-o-programcs)
6. [Criando e Aplicando Migrações](#criando-e-aplicando-migrações)

## Criando um Projeto ASP.NET Core Vazio

1. Abra o Visual Studio ou o terminal.
2. Crie um novo projeto selecionando "ASP.NET Core Web API".
3. Escolha a opção "Empty" (Vazio) para um projeto sem modelos ou controladores pré-configurados.
4. Nomeie seu projeto (por exemplo, ProjectAPITest) e clique em "Create" (Criar).

## Instalando Pacotes do Framework
Abra o terminal ou o Gerenciador de Pacotes NuGet no Visual Studio e execute os seguintes comandos para instalar os pacotes necessários:

~~~shell
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Newtonsoft.Json
dotnet add package Swashbuckle.AspNetCore
~~~

## Criando a Estrutura de Pastas e Classes

### Criando a Pasta `Domain`

1. No Visual Studio, clique com o botão direito no projeto e selecione "Add" > "New Folder" (Adicionar > Nova Pasta).
2. Nomeie a pasta como Domains.
3. Dentro da pasta `Domains`, crie uma classe chamada `Products`:

~~~csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAPITest.Domains
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdProduct { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required("Nome do Produto é Obrigatório.")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required("Preço do produto é obrigatório.")]
        public decimal Price { get; set; }
    }
}

~~~

### Criando a Pasta `Interface`
1. Adicione uma nova pasta chamada `Interface`.
2. Dentro da pasta `Interface`, crie um arquivo chamado `IProductsRepository.cs`:

~~~csharp
using ProjectAPITest.Domains;

namespace ProjectAPITest.Interface
{
    public interface IProductsRepository
    {
        List<Products> Get();
        Products GetById(int id);
        Products Post(Products product);
        Products Put(int id, Products product);
        void Delete(int id);
    }
}

~~~

### Criando o Contexto do Banco de Dados
1. Crie uma pasta chamada `Context`.
2. Dentro da pasta `Context`, crie um arquivo chamado `ProjectApiContextContext.cs`:
~~~csharp
using Microsoft.EntityFrameworkCore;
using ProjectAPITest.Domains;

namespace ProjectAPITest.Context
{
    public class ProjectApiContextContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE12-SALA19\\SQLEXPRESS; Database = ProjectAPITest; User Id = sa; pwd = senai@134; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>()
                .HasData(
                    new Products
                    {
                        IdProduct = Guid.NewGuid(),
                        Name = "Samsung A52s",
                        Price = 2768.90m
                    },
                    new Products
                    {
                        IdProduct = Guid.NewGuid(),
                        Name = "Apple iPhone 15 Pro Max 512 GB -Titânio Natural",
                        Price = 9699m
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
~~~

## Configurando o `Program.cs`
1. No arquivo `Program.cs`, configure os serviços e o pipeline HTTP:
~~~csharp
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Event Plus",
        Description = "Api responsável pelo gerenciamento de um sistema, onde seja possível realizar a gestão de eventos na escola.",
        Contact = new OpenApiContact
        {
            Name = "Allan Rodrigues",
            Email = "allanrodrigues1991.ar@gmail.com",
            Url = new Uri("https://github.com/AllanR1991")
        },
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

~~~


## Criando e Aplicando Migrações

1. Abra o Package Manager Console no Visual Studio (Tools > NuGet Package Manager > Package Manager Console).
2. Execute o comando para criar uma migração:
  ~~~csharp
   Add-Migration InitialCreate
~~~

3. Em seguida, atualize o banco de dados com:
  ~~~csharp
   Update-Database
~~~
