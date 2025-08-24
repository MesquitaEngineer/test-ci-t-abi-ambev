using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Command for creating a new Sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a Sale, 
/// including Salename, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="IList<ListSaleResult></ListSaleResult>"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="ListSaleCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class ListSaleCommand : IRequest<IList<ListSaleResult>>
{
    /// <summary>
    /// Gets or sets the unique identifier of the sale.
    /// Used to filter by a specific sale.
    /// </summary>
    public Guid? Id { get; set; }

    /// <summary>
    /// Gets or sets the Sale Number associated with the sale.
    /// Used to filter sales by Sale Number.
    /// </summary>
    public string? SaleNumber { get; set; }

    /// <summary>
    /// Gets or sets the name of the customer associated with the sale.
    /// Used to filter sales by customer name.
    /// </summary>
    public string? Customer { get; set; }

    /// <summary>
    /// Gets or sets the start date for filtering sales.
    /// Only sales on or after this date will be included.
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date for filtering sales.
    /// Only sales on or before this date will be included.
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// Gets or sets the exact total amount of the sale.
    /// Used to filter sales by a specific total value.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the minimum total amount for filtering sales.
    /// Only sales with totals equal to or greater than this value will be included.
    /// </summary>
    public decimal? MinTotal { get; set; }

    /// <summary>
    /// Gets or sets the maximum total amount for filtering sales.
    /// Only sales with totals equal to or less than this value will be included.
    /// </summary>
    public decimal? MaxTotal { get; set; }

    /// <summary>
    /// Gets or sets the name of the branch where the sale occurred.
    /// Used to filter sales by branch.
    /// </summary>
    public string? Branch { get; set; }

    /// <summary>
    /// Gets or sets the cancellation status of the sale.
    /// Accepts values such as "true" or "false" to filter cancelled or active sales.
    /// </summary>
    public bool? Cancelled { get; set; }


    public ValidationResultDetail Validate()
    {
        var validator = new ListSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}