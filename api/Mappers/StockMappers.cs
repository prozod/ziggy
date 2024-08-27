using api.Dtos.Stock;
using api.Models;

namespace api.Mappers;

public static class StockMappers
{
    public static StockDto ToStockDto(this Stock stockModel)
    {
        return new StockDto
        {
            Id = stockModel.Id,
            Symbol = stockModel.Symbol,
            CompanyName = stockModel.CompanyName,
            Purchase = stockModel.Purchase,
            Dividend = stockModel.Dividend,
            Industry = stockModel.Industry,
            MarketCap = stockModel.MarketCap
        };
    }

    public static Stock ToStockFromCreateDto(this CreateStockReqDto stockDto)
    {
        return new Stock
        {
            Symbol = stockDto.Symbol,
            CompanyName = stockDto.CompanyName,
            Purchase = stockDto.Purchase,
            Dividend = stockDto.Dividend,
            Industry = stockDto.Industry,
            MarketCap = stockDto.MarketCap
        };
    }

    public static void UpdateStockFromDto(this Stock stock, UpdateStockRequestDto updatedStock)
    {
        stock.Symbol = updatedStock.Symbol;
        stock.CompanyName = updatedStock.CompanyName;
        stock.Dividend = updatedStock.Dividend;
        stock.Purchase = updatedStock.Purchase;
        stock.MarketCap = updatedStock.MarketCap;
        stock.Industry = updatedStock.Industry;
    }
}