using MediatR;
using Products.Application.Common.Exceptions;
using Products.Application.Common.Interfaces;
using Products.Domain.Entities;

namespace Products.Application.ProductOptions.Commands.UpdateProductOption;
public record UpdateProductOptionCommand : IRequest
{
    public Guid Id { get; init; }
    public string Name { get; init; }

    public string Description { get; init; }
}

public class UpdateProductOptionCommandHandler : IRequestHandler<UpdateProductOptionCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProductOptionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateProductOptionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ProductOptions
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ProductOption), request.Id);
        }

        entity.Name = request.Name;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}