using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a sale item in the system.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class SaleItem : BaseEntity
{

    /// <summary>
    /// Gets or sets the name of the product associated with this sale item.
    /// </summary>
    public string? Product { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product sold.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product at the time of sale.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount applied to this sale item.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets or sets the total amount for this sale item after applying discounts.
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this sale item has been cancelled.
    /// </summary>
    public bool Cancelled { get; set; } = false;

    /// <summary>
    /// Gets or sets the identifier of the associated sale transaction.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// Gets or sets the sale transaction to which this item belongs.
    /// </summary>
    public Sale? Sale { get; set; }
}