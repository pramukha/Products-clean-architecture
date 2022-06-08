namespace Products.Domain.Entities;
public class Product: BaseEntity<Guid>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public decimal DeliveryPrice { get; set; }

    public virtual IList<ProductOption> ProductOptions { get; set; }
}
