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

    public async Task<Sale> CreateSaleAsync(Sale command, CancellationToken cancellationToken)
    {
        var sale = new Sale
        {
            Id = Guid.NewGuid(),
            SaleNumber = command.SaleNumber,
            Date = command.Date,
            Customer = command.Customer,
            Branch = command.Branch,
            Items = new List<SaleItem>()
        };

        decimal totalAmount = 0;

        foreach (var item in command.Items)
        {
            var discount = this.CalculateDiscount(item.Quantity, item.UnitPrice);
            var total = item.UnitPrice * item.Quantity - discount;

            sale.Items.Add(new SaleItem
            {
                Id = Guid.NewGuid(),
                Product = item.Product,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                Discount = discount,
                Total = total,
                SaleId = sale.Id
            });

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
