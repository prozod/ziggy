using api.Dtos.Stock;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces;

public interface IStockRepository
{
    Task<List<StockDto>> GetAllAsync();
    Task<Stock?> GetByIdAsync(int id);
    Task<Stock?> CreateAsync(CreateStockReqDto stockReq);
    Task<StockDto?> UpdateAsync(int id, UpdateStockRequestDto updateDto);
    Task<bool> Delete(int id);
}