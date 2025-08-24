using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;

/// <summary>
/// Validator for ListSaleRequest that defines validation rules for Sale creation.
/// </summary>
public class ListSaleItemRequestValidator : AbstractValidator<ListSaleItemRequest>
{
    public ListSaleItemRequestValidator()
    {
        RuleFor(Sale => Sale.Product).NotEmpty();
        RuleFor(Sale => Sale.Quantity).NotEmpty();
        RuleFor(Sale => Sale.UnitPrice).NotEmpty();
    }
}