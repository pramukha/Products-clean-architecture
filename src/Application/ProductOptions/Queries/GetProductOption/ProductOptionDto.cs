using Products.Application.Common.Mappings;
using Products.Domain.Entities;

namespace Products.Application.ProductOptions.Queries.GetProductOption;
public class ProductOptionDto : IMapFrom<ProductOption>
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}
