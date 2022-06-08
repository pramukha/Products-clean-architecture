
using Products.Application.Common.Mappings;
using Products.Domain.Entities;

namespace Products.Application.Products.Queries.GetProducts;
public class ProductListDto : IMapFrom<Product>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public decimal DeliveryPrice { get; set; }
}
