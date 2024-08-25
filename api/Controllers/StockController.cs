using api.Data;
using api.Dtos.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/stock")]
[ApiController]
public class StockController : ControllerBase
{
    private readonly AppDbContext _ctx;

    public StockController(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var stocks = _ctx.Stock
            .Select(stockModel => stockModel.ToStockDto());

        return Ok(stocks.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var stock = _ctx.Stock.Find(id);
        if (stock == null) return NotFound();
        return Ok(stock.ToStockDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateStockReqDto stockDto)
    {
        var stockModel = stockDto.ToStockFromCreateDto();
        _ctx.Stock.Add(stockModel);
        _ctx.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateDto)
    {
        var stockModel = _ctx.Stock.FirstOrDefault(x => x.Id == id);
        if (stockModel == null) return NotFound();
        stockModel.Symbol = updateDto.Symbol;
        stockModel.CompanyName = updateDto.CompanyName;
        stockModel.Dividend = updateDto.Dividend;
        stockModel.Purchase = updateDto.Purchase;
        stockModel.MarketCap = updateDto.MarketCap;
        stockModel.Industry = updateDto.Industry;
        _ctx.SaveChanges();
        return Ok(stockModel.ToStockDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var stock = _ctx.Stock.FirstOrDefault(x => x.Id == id);
        if (stock == null) return NotFound();
        _ctx.Stock.Remove(stock);
        _ctx.SaveChanges();
        return NoContent();
    }
}