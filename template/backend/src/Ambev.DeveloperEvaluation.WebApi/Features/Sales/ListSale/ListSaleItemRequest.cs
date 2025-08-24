using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;

/// <summary>
/// Represents a request to List a new Sale Item in the system.
/// </summary>
public class ListSaleItemRequest
{
    public string? Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

}