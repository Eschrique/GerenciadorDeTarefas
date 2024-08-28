using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using GerenciadorDeTarefas.Infrastructure.Data;

namespace GerenciadorDeTarefas.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Host=172.17.0.2;Port=5432;Database=gerenciador_tarefas;Username=admin;Password=admin123;"); // Use sua string de conexão aqui

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
