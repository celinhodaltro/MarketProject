using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Configuration;

public class ApplicationDbContext : DbContext
{
  public string ConnectionString { get; set; } = "Server=localhost;Database=Main;Uid=root;Pwd=admin";


  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseMySQL(ConnectionString);
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }


  //public DbSet<SeuModelo> SeusModelos { get; set; }


}



