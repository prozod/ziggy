using System.Diagnostics;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class StockRepository : IStockRepository
{
    private readonly AppDbContext _context;

    public StockRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<StockDto>> GetAllAsync()
    {
        return await _context.Stock
            .Select(stockModel => stockModel.ToStockDto()).ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await _context.Stock.FindAsync(id);
    }

    public async Task<Stock?> CreateAsync(CreateStockReqDto stockReq)
    {
        var stockModel = stockReq.ToStockFromCreateDto();
        await _context.Stock.AddAsync(stockModel);
        await _context.SaveChangesAsync();
        return stockModel;
    }

    public async Task<StockDto?> UpdateAsync(int id, UpdateStockRequestDto updateDto)
    {
        var stock = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
        if (stock == null) return null;
        stock.UpdateStockFromDto(updateDto);
        await _context.SaveChangesAsync();
        return stock.ToStockDto();
    }

    public async Task<bool> Delete(int id)
    {
        var stock = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
        if (stock == null) return false;
        _context.Stock.Remove(stock);
        await _context.SaveChangesAsync();
        return true;
    }
}