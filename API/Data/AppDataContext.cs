using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API;

public class ApplicationContext : DbContext
{
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<FolhaPagamento> FolhasPagamento { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
}

