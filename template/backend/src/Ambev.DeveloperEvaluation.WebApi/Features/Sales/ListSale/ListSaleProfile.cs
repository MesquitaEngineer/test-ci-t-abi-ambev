using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.ListSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSale;

/// <summary>
/// Profile for mapping between Application and API ListSale responses
/// </summary>
public class ListSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for ListSale feature
    /// </summary>
    public ListSaleProfile()
    {
        CreateMap<ListSaleRequest, ListSaleCommand>();
        CreateMap<ListSaleResult, ListSaleResponse>();
    }
}
