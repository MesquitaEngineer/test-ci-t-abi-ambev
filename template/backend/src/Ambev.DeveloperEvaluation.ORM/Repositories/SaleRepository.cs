using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleRepository using Entity Framework Core
/// </summary>
public class SaleRepository : Repository<Sale>, ISaleRepository
{

    /// <summary>
    /// Initializes a new instance of SaleRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleRepository(DefaultContext context) : base(context)
    {
    }
    
    /// <summary>
    /// Retrieves any Sales by  identifier
    /// </summary>
    /// <param name="saleNumber">A identifier of the Sales</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Sales if found, null otherwise</returns>
    public async Task<List<Sale>?> GetBySaleNumberAsync(string saleNumber, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Sale>()
         .Where(o => o.SaleNumber == saleNumber)
         .ToListAsync(cancellationToken);
    }

}
