// Placeholder for IInventoryService.cs file
using Ambev.DeveloperEvaluation.Domain.Entities;
namespace Ambev.DeveloperEvaluation.Domain.Services;
public interface ISaleService
{
    Task<Sale> CreateSaleAsync(Sale sale, CancellationToken cancellationToken);
}
