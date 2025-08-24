using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Handler for processing ListSaleCommand requests
/// </summary>
public class ListSaleHandler : IRequestHandler<ListSaleCommand, IList<ListSaleResult>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public ListSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<IList<ListSaleResult>> Handle(ListSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new ListSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sales = await _saleRepository.GetAllAsync(cancellationToken);

            if (!sales.Any())
            throw new InvalidOperationException($"No Sales found!");

        // Convert sales to a list to avoid IEnumerable to List conversion issues
        var salesList = sales.ToList();

        if (command.Id.HasValue && command.Id.Value != Guid.Empty)
            salesList = salesList.Where(s => s.Id == command.Id.Value).ToList();

        if (!string.IsNullOrEmpty(command.Customer))
            salesList = salesList.Where(s => s.Customer != null && s.Customer.Contains(command.Customer)).ToList();

        if (command.StartDate.HasValue)
            salesList = salesList.Where(s => s.Date >= command.StartDate.Value).ToList();

        if (command.EndDate.HasValue)
            salesList = salesList.Where(s => s.Date <= command.EndDate.Value).ToList();

        if (command.Cancelled.HasValue)
            salesList = salesList.Where(s => s.Cancelled == command.Cancelled.Value).ToList();

        if (command.MinTotal.HasValue)
            salesList = salesList.Where(s => s.TotalAmount >= command.MinTotal.Value).ToList();

        if (command.MaxTotal.HasValue)
            salesList = salesList.Where(s => s.TotalAmount <= command.MaxTotal.Value).ToList();

        if (!string.IsNullOrEmpty(command.Branch))
            salesList = salesList.Where(s => s.Branch == command.Branch).ToList();

        var mappedResult = _mapper.Map<IList<ListSaleResult>>(salesList);

        return mappedResult;
    }
}

