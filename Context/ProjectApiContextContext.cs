using Microsoft.EntityFrameworkCore;
using ProjectAPITest.Domains;

namespace ProjectAPITest.Context
{
    public class ProjectApiContextContext : DbContext
    {
        /// <summary>
        /// Dbset<> é utilizado para efetuar as consultas no banco de dados.
        /// Utilização : Dbset<ClasseDomain> nomeQualquer {get; set;}
        /// </summary>
        public DbSet<Products> Products { get; set; }

        /// <summary>
        /// Configurando o acesso ao banco de dados.
        /// </summary>
        /// <param name="optionsBuilder"> Um construtor de opções do contexto do banco de dados. Este objeto permite a configuração das opções do DbContext, como o provedor de banco de dados a ser usado, a string de conexão, e outras configurações específicas do provedor.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE12-SALA19\\SQLEXPRESS; Database = ProjectAPITest; User Id = sa; pwd = senai@134; TrustServerCertificate=True;");
        }

        /// <summary>
        /// Configurando dados presetados nos banco de dados.
        /// </summary>
        /// <param name="modelBuilder"> Um construtor de modelos do Entity Framework. Este objeto é usado para configurar mapeamentos entre as entidades do domínio e as tabelas do banco de dados, definir relações entre entidades, configurar chaves primárias e estrangeiras, e configurar dados inicializados (seeding) no banco de dados.</param>
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
