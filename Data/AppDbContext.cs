// Importação das bibliotecas necessárias
using Microsoft.EntityFrameworkCore;
using ProjetoDBZ.Models;

namespace ProjetoDBZ.Data;

// Classe que representa o contexto do banco de dados, herdando de DbContext
public class AppDbContext : DbContext
{
    // Construtor que recebe as opções de configuração do banco de dados
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    // Declaração das tabelas do banco de dados usando DbSet
    // Representa a tabela de Personagens
    public DbSet<Personagem> Personagens { get; set; }
    // Representa a tabela de Transformações
    public DbSet<Transformacao> Transformacoes { get; set; }
    
    // Método para configurar o modelo de dados usando Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Chama o método da classe base
        base.OnModelCreating(modelBuilder);
        
        // Configuração da entidade Personagem
        modelBuilder.Entity<Personagem>(entity =>
        {
            // Define a chave primária
            entity.HasKey(p => p.Id);
            // Configura o campo Nome como obrigatório e com tamanho máximo de 100 caracteres
            entity.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            // Define o tamanho máximo de 50 caracteres para o campo Raca
            entity.Property(p => p.Raca).HasMaxLength(50);
            // Define o tamanho máximo de 200 caracteres para o campo TecnicaEspecial
            entity.Property(p => p.TecnicaEspecial).HasMaxLength(200);
            
            // Configura o relacionamento 1:N entre Personagem e Transformações
            // Um personagem pode ter várias transformações
            entity.HasMany(p => p.Transformacoes)
                  // Uma transformação pertence a um personagem
                  .WithOne(t => t.Personagem)
                  // Define a chave estrangeira na tabela de Transformações
                  .HasForeignKey(t => t.PersonagemId);
        });
        
        // Configuração da entidade Transformação
        modelBuilder.Entity<Transformacao>(entity =>
        {
            // Define a chave primária
            entity.HasKey(t => t.Id);
            // Configura o campo Nome como obrigatório e com tamanho máximo de 100 caracteres
            entity.Property(t => t.Nome).IsRequired().HasMaxLength(100);
            // Define o tamanho máximo de 500 caracteres para o campo Descricao
            entity.Property(t => t.Descricao).HasMaxLength(500);
        });
    }
}