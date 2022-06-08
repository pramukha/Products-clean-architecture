using FluentValidation;

namespace Products.Application.ProductOptions.Commands.UpdateProductOption;
public class UpdateProductOptionCommandValidator : AbstractValidator<UpdateProductOptionCommand>
{
    public UpdateProductOptionCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(100)
            .NotEmpty();

        RuleFor(v => v.Description)
            .MaximumLength(500)
            .NotEmpty();
    }
}