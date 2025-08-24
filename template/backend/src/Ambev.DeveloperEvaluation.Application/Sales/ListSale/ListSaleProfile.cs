using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Profile for mapping between Sale entity and ListSaleResponse
/// </summary>
public class ListSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListSale operation
    /// </summary>
    public ListSaleProfile()
    {
        CreateMap<ListSaleCommand, Sale>();
        CreateMap<Sale, ListSaleResult>();
    }
}
