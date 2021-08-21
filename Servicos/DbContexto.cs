using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using apresentacao.Models;



  namespace apresentacao.Servicos
{
  public class DbContexto : DbContext
  {
    public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }
    public DbSet<Vaga> Vagas { get; set; }
    public DbSet<Candidato> Candidatos { get; set; }
    
  }
}