using BestDeal.Api.ViewModels;
using BestDeal.Models.Deals;
using BestDeal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BestDeal.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MercadoLibreController : ControllerBase
{
    private readonly IMercadoLibreService _mercadoLibreService;

    public MercadoLibreController(IMercadoLibreService mercadoLibreService)
    {
        _mercadoLibreService = mercadoLibreService;
    }

    [HttpGet]
    public IActionResult Deal(MercadoLibreViewModel mercadoLibre)
    {
        DealRequest request = new DealRequest() { Name = mercadoLibre.Title, Price = mercadoLibre.Price };
        var result = _mercadoLibreService.GetDeal(request);
        
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}