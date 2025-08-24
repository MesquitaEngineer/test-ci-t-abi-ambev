using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;

/// <summary>
/// Validator for <see cref="ListSaleRequest"/> that defines validation rules for filtering sales.
/// </summary>
public class ListSaleRequestValidator : AbstractValidator<ListSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListSaleRequestValidator"/> with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleNumber: Optional, max 50 characters
    /// - Customer: Optional, max 100 characters
    /// - Branch: Optional, max 100 characters
    /// - StartDate and EndDate: Must not be in the future; StartDate must be before or equal to EndDate
    /// - MinTotal and MaxTotal: Must be non-negative; MinTotal must be less than or equal to MaxTotal
    /// - Cancelled: Must be "true", "false", or empty
    /// </remarks>
    public ListSaleRequestValidator()
    {
        RuleFor(x => x.StartDate)
            .LessThanOrEqualTo(DateTime.Today)
            .When(x => x.StartDate.HasValue)
            .WithMessage("StartDate cannot be in the future.");

        RuleFor(x => x.EndDate)
            .LessThanOrEqualTo(DateTime.Today)
            .When(x => x.EndDate.HasValue)
            .WithMessage("EndDate cannot be in the future.");

        RuleFor(x => x)
            .Must(x => !x.StartDate.HasValue || !x.EndDate.HasValue || x.StartDate <= x.EndDate)
            .WithMessage("StartDate must be earlier than or equal to EndDate.");

        RuleFor(x => x.MinTotal)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MinTotal.HasValue)
            .WithMessage("MinTotal must be non-negative.");

        RuleFor(x => x.MaxTotal)
            .GreaterThanOrEqualTo(0)
            .When(x => x.MaxTotal.HasValue)
            .WithMessage("MaxTotal must be non-negative.");

        RuleFor(x => x)
            .Must(x => !x.MinTotal.HasValue || !x.MaxTotal.HasValue || x.MinTotal <= x.MaxTotal)
            .WithMessage("MinTotal must be less than or equal to MaxTotal.");

        RuleFor(x => x.Cancelled)
            .Must(value => !value.HasValue || value == true || value == false)
            .WithMessage("Cancelled must be 'true', 'false', or empty.");
    }
}
