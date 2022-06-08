using Microsoft.AspNetCore.Mvc;
using Products.Application.ProductOptions.Commands.CreateProductOption;
using Products.Application.ProductOptions.Commands.DeleteProductOption;
using Products.Application.ProductOptions.Commands.UpdateProductOption;
using Products.Application.ProductOptions.Queries.GetProductOption;
using Products.Application.ProductOptions.Queries.GetProductOptions;
using Products.Application.Products.Commands.CreateProduct;
using Products.Application.Products.Commands.DeleteProduct;
using Products.Application.Products.Commands.UpdateProduct;
using Products.Application.Products.Queries.GetProduct;
using Products.Application.Products.Queries.GetProducts;
using Products.Application.Products.Queries.GetProductsByName;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ApiControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(Guid id)
    {
        var result = await Mediator.Send(new GetProductQuery(id));
        return result==null ? NotFound() : result;
    }

    [HttpGet]
    public async Task<ActionResult<Products.Application.Common.Models.PaginatedList<ProductListDto>>> GetProducts([FromQuery] GetProductsQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("search")]
    public async Task<ActionResult<Products.Application.Common.Models.PaginatedList<ProductSearchDto>>> GetProductsByName([FromQuery] GetProductsByNameQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateProductCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, UpdateProductCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        await Mediator.Send(new DeleteProductCommand(id));

        return NoContent();
    }

    [HttpGet("{productId}/options/{id}")]
    public async Task<ActionResult<ProductOptionDto>> GetProductOption(Guid productId, Guid id)
    {
        return await Mediator.Send(new GetProductOptionQuery { Id = id, ProductId = productId });
    }

    [HttpGet("{productId}/options")]
    public async Task<ActionResult<Products.Application.Common.Models.PaginatedList<ProductOptionListDto>>> GetProductOptions(Guid productId, [FromQuery] ProductOptionsPaging query)
    {
        return await Mediator.Send(new GetProductOptionsQuery {ProductId = productId,PageNumber = query.PageNumber, PageSize = query.PageSize });
    }

    [HttpPost("{productId}/options")]
    public async Task<ActionResult<Guid>> CreateOption(Guid productId, CreateProductOption command)
    {
        return await Mediator.Send(new CreateProductOptionCommand { ProductId = productId, Description = command.Description, Name = command.Name });
    }

    [HttpPut("{productId}/options/{id}")]
    public async Task<ActionResult> UpdateOption(Guid productId, Guid id, UpdateProductOptionCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{productId}/options/{id}")]
    public async Task<ActionResult> DeleteOption(Guid productId, Guid id)
    {
        await Mediator.Send(new DeleteProductOptionCommand(id));

        return NoContent();
    }
}
