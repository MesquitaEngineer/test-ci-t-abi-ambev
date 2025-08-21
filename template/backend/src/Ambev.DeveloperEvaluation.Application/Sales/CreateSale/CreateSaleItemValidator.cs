using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for Sale creation command.
/// </summary>
public class CreateSaleItemCommandValidator : AbstractValidator<CreateSaleItemCommand>
{
    
    public CreateSaleItemCommandValidator()
    {
        RuleFor(Sale => Sale.Product).NotEmpty();
        RuleFor(Sale => Sale.Quantity).NotEmpty();
        RuleFor(Sale => Sale.UnitPrice).NotEmpty();
    }
}