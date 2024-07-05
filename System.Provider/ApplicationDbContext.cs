using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Configuration;
using System.Entities;

public class ApplicationDbContext : DbContext
{
  public string ConnectionString { get; set; } = "Server=localhost;Database=Main;Uid=root;Pwd=admin";


  public ApplicationDbContext() { }
  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
  {
  }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseMySQL(ConnectionString);
    }
  }


  public DbSet<Account> Accounts { get; set; }


}



