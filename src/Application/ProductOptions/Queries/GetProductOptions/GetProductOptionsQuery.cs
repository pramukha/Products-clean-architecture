using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Products.Application.Common.Interfaces;
using Products.Application.Common.Mappings;
using Products.Application.Common.Models;

namespace Products.Application.ProductOptions.Queries.GetProductOptions;
public record GetProductOptionsQuery : IRequest<PaginatedList<ProductOptionListDto>>
{
    public Guid ProductId { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetProductOptionsQueryHandler : IRequestHandler<GetProductOptionsQuery, PaginatedList<ProductOptionListDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductOptionsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProductOptionListDto>> Handle(GetProductOptionsQuery request, CancellationToken cancellationToken)
    {
        return await _context.ProductOptions
            .Where(p => p.ProductId == request.ProductId)
            .OrderBy(x => x.Name)
            .ProjectTo<ProductOptionListDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}