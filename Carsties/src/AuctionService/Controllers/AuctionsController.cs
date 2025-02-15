using AuctionService.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuctionService.Controllers;

[ApiController]
[Route("api/auctions")]
public class AuctionsController: ControllerBase
{
    private readonly AuctionDbContext context;
    public AuctionsController(AuctionDbContext context, IMapper mapper)
    {
        this.context = context;
    }
}