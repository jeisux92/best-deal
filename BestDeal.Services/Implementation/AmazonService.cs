using BestDeal.Models.Deals;
using BestDeal.Repository.Models;
using BestDeal.Repository.Repositories;

namespace BestDeal.Services.Implementation;

public class AmazonService : IAmazonService
{
    private readonly IAmazonRepository _amazonRepository;

    public AmazonService(IAmazonRepository amazonRepository)
    {
        _amazonRepository = amazonRepository;
    }

    public DealResponse GetDeal(DealRequest request)
    {
        IEnumerable<AmazonProduct> products = _amazonRepository.GetProductsByNameAndPrice(request.Name, request.Price);
        AmazonProduct product = products.MinBy(x => x.Price);
        if (product is null)
        {
            return null;
        }
        return new DealResponse { Name = product.Name, Description = product.Description, Price = product.Price };
    }
}