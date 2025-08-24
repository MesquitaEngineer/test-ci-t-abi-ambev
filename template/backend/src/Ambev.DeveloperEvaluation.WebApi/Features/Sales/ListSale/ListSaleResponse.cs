using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;

/// <summary>
/// API response model for ListSale operation
/// </summary>
public class ListSaleResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the sale.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the sale's reference number.
    /// Must not be null or empty.
    /// </summary>
    public string? SaleNumber { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the sale was created.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the name of the customer associated with the sale.
    /// </summary>
    public string? Customer { get; set; }

    /// <summary>
    /// Gets or sets the total monetary value of the sale.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the name of the branch where the sale occurred.
    /// </summary>
    public string? Branch { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the sale has been cancelled.
    /// </summary>
    public bool Cancelled { get; set; } = false;

    /// <summary>
    /// Gets or sets the collection of items included in the sale.
    /// </summary>

}
