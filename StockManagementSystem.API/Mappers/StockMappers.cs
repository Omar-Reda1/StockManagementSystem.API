// Ignore Spelling: Dto

using StockManagementSystem.API.DTOs.Stock;
using StockManagementSystem.API.Models;

namespace StockManagementSystem.API.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                LastDiv = stockModel.LastDiv,
                Purchase = stockModel.Purchase,
                Industry= stockModel.Industry,
                MarketCap= stockModel.MarketCap,
            };
        }
        public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto)
        {
            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                LastDiv = stockDto.LastDiv,
                Purchase = stockDto.Purchase,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap,

            };
        }
    }
}
