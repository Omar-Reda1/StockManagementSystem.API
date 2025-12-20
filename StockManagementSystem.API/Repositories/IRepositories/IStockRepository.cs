using StockManagementSystem.API.DTOs.Stock;
using StockManagementSystem.API.Helpers;
using StockManagementSystem.API.Models;

namespace StockManagementSystem.API.Repositories.IRepositories
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id , UpdateStockRequestDto stockDto);
        Task<Stock?> DeleteAsync(int id);
        Task<bool> IsStockExists(int id);
    }
}
