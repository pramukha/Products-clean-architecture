using Products.Application.Common.Mappings;
using Products.Domain.Entities;

namespace Products.Application.Products.Queries.GetProduct;
public class ProductDto : IMapFrom<Product>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public decimal DeliveryPrice { get; set; }
}
