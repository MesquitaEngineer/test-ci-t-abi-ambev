using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;

/// <summary>
/// Represents a request to list sales in the system based on optional filtering criteria.
/// </summary>
public class ListSaleRequest
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
}