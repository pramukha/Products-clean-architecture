using MediatR;
using Products.Application.Common.Interfaces;
using Products.Domain.Entities;

namespace Products.Application.ProductOptions.Commands.CreateProductOption;
public record CreateProductOptionCommand : IRequest<Guid>
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }
}

public class CreateProductOptionCommandHandler : IRequestHandler<CreateProductOptionCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateProductOptionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateProductOptionCommand request, CancellationToken cancellationToken)
    {
        var entity = new ProductOption
        {
            ProductId = request.ProductId,
            Name = request.Name,
            Description = request.Description
        };

        _context.ProductOptions.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}