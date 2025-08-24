using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Sale entity operations
/// </summary>
public interface ISaleRepository : IRepository<Sale>
{
    /// <summary>
    /// Retrieves any Sales by  identifier
    /// </summary>
    /// <param name="saleNumber">A identifier of the Sales</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Sales if found, null otherwise</returns>
    Task<List<Sale>?> GetBySaleNumberAsync(string saleNumber, CancellationToken cancellationToken = default);

   
}
