using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Products.Application.Common.Interfaces;

namespace Products.Application.ProductOptions.Queries.GetProductOption;
public record GetProductOptionQuery : IRequest<ProductOptionDto>
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
}

public class GetProductOptionQueryHandler : IRequestHandler<GetProductOptionQuery, ProductOptionDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductOptionQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductOptionDto> Handle(GetProductOptionQuery request, CancellationToken cancellationToken)
    {
        var option = await _context.ProductOptions
            .ProjectTo<ProductOptionDto>(_mapper.ConfigurationProvider)
            .Where(x => x.Id == request.Id).Distinct()
            .FirstOrDefaultAsync(cancellationToken);

        return option;
    }
}