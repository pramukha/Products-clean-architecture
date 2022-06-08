namespace Products.Domain.Entities;
public class ProductOption: BaseEntity<Guid>
{
    public Guid ProductId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual Product Product { get; set; }
}
