using Microsoft.EntityFrameworkCore;
using GerenciadorDeTarefas.Web.Models;

namespace GerenciadorDeTarefas.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
