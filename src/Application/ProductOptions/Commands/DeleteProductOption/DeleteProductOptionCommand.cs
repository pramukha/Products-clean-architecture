using MediatR;
using Products.Application.Common.Exceptions;
using Products.Application.Common.Interfaces;
using Products.Domain.Entities;

namespace Products.Application.ProductOptions.Commands.DeleteProductOption;
public record DeleteProductOptionCommand(Guid Id) : IRequest;

public class DeleteProductOptionCommandHandler : IRequestHandler<DeleteProductOptionCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteProductOptionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteProductOptionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.ProductOptions
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(ProductOption), request.Id);
        }

        _context.ProductOptions.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}