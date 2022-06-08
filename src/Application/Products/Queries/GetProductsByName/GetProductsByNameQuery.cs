using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Products.Application.Common.Interfaces;
using Products.Application.Common.Mappings;
using Products.Application.Common.Models;

namespace Products.Application.Products.Queries.GetProductsByName;

public record GetProductsByNameQuery : IRequest<PaginatedList<ProductSearchDto>>
{
    public string Name { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetProductsByNameQueryHandler : IRequestHandler<GetProductsByNameQuery, PaginatedList<ProductSearchDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductsByNameQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProductSearchDto>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products
            .Where(p => p.Name.ToLower().Contains(request.Name.ToLower()))
            .ProjectTo<ProductSearchDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
