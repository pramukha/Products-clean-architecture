using Products.Application.Common.Mappings;
using Products.Domain.Entities;

namespace Products.Application.ProductOptions.Queries.GetProductOptions;
public class ProductOptionListDto : IMapFrom<ProductOption>
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}
