// ponte entre C# e o banco de dados, permitindo que o Entity Framework Core interaja com o banco de dados

// "using" utilizado para adicionar dependências
using AutoFix.Models;
using Microsoft.EntityFrameworkCore;

// AppDbContext que herda DbContext extendendo o comportamento padrão EF Core
// DbContext é a classe base que representa uma sessão com o banco de dados, permitindo que você consulte e salve dados (ORM)

public class AppDbContext : DbContext
{
    // Construtor que recebe as opções de configuração do banco de dados e as passa para a classe base DbContext
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Ele vai procurar a tabela chamada Usuarios e vai guardar os dados do tipo Usuario
    // DbSet<T> representa uma tabela no banco
    // O EF Core vai usar essa propriedade pra criar a tabela e gerar queries
    public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<CategoriaAtributo> CategoriaAtributos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<ProdutoAtributo> ProdutoAtributos { get; set; }

}


// Qualquer alteração no BD coluna, tabela... rodar o comando "dotnet ef migrations add "nome" e depois "dotnet ef database update"
