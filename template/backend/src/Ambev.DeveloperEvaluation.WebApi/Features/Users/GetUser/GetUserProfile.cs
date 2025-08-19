using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

/// <summary>
/// Profile for mapping GetUser feature requests to commands
/// </summary>
public class GetSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser feature
    /// </summary>
    public GetSaleProfile()
    {
        CreateMap<Guid, Application.Users.GetUser.GetSaleCommand>()
            .ConstructUsing(id => new Application.Users.GetUser.GetUserCommand(id));

        CreateMap<GetSaleResult, GetSaleResponse>();
            

    }
}
