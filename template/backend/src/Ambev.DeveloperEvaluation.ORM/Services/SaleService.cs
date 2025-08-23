// Placeholder for IInventoryService.cs file
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;

namespace Ambev.DeveloperEvaluation.ORM.Services;
public class SaleService : ISaleService
{
    private readonly ISaleRepository _saleRepository;

    public SaleService(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<Sale> CreateSaleAsync(Sale sale, CancellationToken cancellationToken)
    {

        var sales = await _saleRepository.GetBySaleNumberAsync(sale.SaleNumber, cancellationToken);

        if (sales != null && sales.Any())
            throw new ArgumentException("Existe vendas com esse número.");

        decimal totalAmount = 0;

        foreach (var item in sale.Items)
        {
            var discount = this.CalculateDiscount(item.Quantity, item.UnitPrice);
            var total = item.UnitPrice * item.Quantity - discount;
            item.Discount = discount;
            item.Total = total;
            
            totalAmount += total;
        }

        sale.TotalAmount = totalAmount;

        await _saleRepository.CreateAsync(sale, cancellationToken);
        return sale;
    }


    private decimal CalculateDiscount(int quantity, decimal unitPrice)
    {
        if (quantity < 4) return 0;
        if (quantity >= 4 && quantity < 10) return 0.10m * unitPrice * quantity;
        if (quantity >= 10 && quantity <= 20) return 0.20m * unitPrice * quantity;
        throw new ArgumentException("Não é permitido vender mais de 20 unidades do mesmo item.");
    }


}
