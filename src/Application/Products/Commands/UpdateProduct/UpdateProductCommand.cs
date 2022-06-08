using MediatR;
using Products.Application.Common.Exceptions;
using Products.Application.Common.Interfaces;
using Products.Domain.Entities;

namespace Products.Application.Products.Commands.UpdateProduct;
public record UpdateProductCommand : IRequest
{
    public Guid Id { get; init; }
    public string Name { get; init; }

    public string Description { get; init; }

    public decimal Price { get; init; }

    public decimal DeliveryPrice { get; init; }
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Products
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Price = request.Price;
        entity.DeliveryPrice = request.DeliveryPrice;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}