using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;



public class Sale : BaseEntity
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; }
    public DateTime Date { get; set; }
    public string Customer { get; set; }
    public decimal TotalAmount { get; set; }
    public string Branch { get; set; }
    public bool Cancelled { get; set; } = false;
    public List<SaleItem> Items { get; set; } = new();

}