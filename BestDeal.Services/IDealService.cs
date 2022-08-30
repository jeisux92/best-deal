using BestDeal.Models.Deals;

namespace BestDeal.Services;

public interface IDealService
{
    DealResponse GetDeal(DealRequest request);
}