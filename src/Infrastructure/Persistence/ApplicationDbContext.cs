using System.Reflection;
using Products.Application.Common.Interfaces;
using Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Products.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
     public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
        
    }

    public DbSet<Product> Products => Set<Product>();

    public DbSet<ProductOption> ProductOptions => Set<ProductOption>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
