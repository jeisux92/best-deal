using BestDeal.Api.ViewModels;
using BestDeal.Models.Deals;
using BestDeal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestDeal.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EbayController : ControllerBase
{
    private readonly IEbayService _ebayDealService;

    public EbayController(IEbayService ebayDealService)
    {
        _ebayDealService = ebayDealService;
    }

    [HttpGet]
    public IActionResult Deal(EbayViewModel ebay)
    {
        DealRequest request = new DealRequest() { Name = ebay.Name, Price = ebay.Value };
        var result = _ebayDealService.GetDeal(request);
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}