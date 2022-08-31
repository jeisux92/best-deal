using BestDeal.Api.ViewModels;
using BestDeal.Models.Deals;
using BestDeal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestDeal.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AmazonController : ControllerBase
{
    private readonly IAmazonService _amazonService;

    public AmazonController(IAmazonService amazonService)
    {
        _amazonService = amazonService;
    }

    [HttpGet]
    public IActionResult Deal(AmazonViewModel amazon)
    {
        DealRequest request = new DealRequest() { Name = amazon.ProductTitle, Price = amazon.MaxPrice };
        var result = _amazonService.GetDeal(request);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}