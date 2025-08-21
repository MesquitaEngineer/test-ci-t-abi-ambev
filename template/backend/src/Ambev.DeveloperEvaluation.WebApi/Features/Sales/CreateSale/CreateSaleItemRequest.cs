using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new Sale Item in the system.
/// </summary>
public class CreateSaleItemRequest
{
    public string Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

}