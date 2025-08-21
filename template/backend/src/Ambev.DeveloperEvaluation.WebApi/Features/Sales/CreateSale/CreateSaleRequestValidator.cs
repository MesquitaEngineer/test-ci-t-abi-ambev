using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for Sale creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(s => s.SaleNumber).NotEmpty();
        RuleFor(s => s.Date).NotEmpty();
        RuleFor(s => s.Customer).NotEmpty();
        RuleFor(s => s.Branch).NotEmpty();
        RuleFor(s => s.Items).NotEmpty();

        RuleForEach(s => s.Items).SetValidator(new CreateSaleItemRequestValidator());
    }
}
