using Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Products.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Product> Products { get; }

    DbSet<ProductOption> ProductOptions { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
