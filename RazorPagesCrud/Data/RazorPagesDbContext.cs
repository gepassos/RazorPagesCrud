using Microsoft.EntityFrameworkCore;
using RazorPagesCrud.Models.Domain;

namespace RazorPagesCrud.Data
{
    public class RazorPagesDbContext: DbContext
    {
        public RazorPagesDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
