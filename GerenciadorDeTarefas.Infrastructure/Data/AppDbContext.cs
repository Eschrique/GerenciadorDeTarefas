using Microsoft.EntityFrameworkCore;
using GerenciadorDeTarefas.Domain.Entities;

namespace GerenciadorDeTarefas.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações para a entidade Usuario
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Tarefas)
                .WithOne(t => t.Usuario)
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Nome)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Email)
                .HasMaxLength(150)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique(); 

            // Configurações para a entidade Tarefa
            modelBuilder.Entity<Tarefa>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Titulo)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Descricao)
                .HasMaxLength(1000);

            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Usuario)
                .WithMany(u => u.Tarefas)
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
