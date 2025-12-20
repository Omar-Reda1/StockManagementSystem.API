using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockManagementSystem.API.DataAccess;
using StockManagementSystem.API.DTOs.Stock;
using StockManagementSystem.API.Mappers;
using StockManagementSystem.API.Repositories.IRepositories;
using System.Threading.Tasks;

namespace StockManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStockRepository _stockRepository;

        public StocksController(ApplicationDbContext context , IStockRepository stockRepository)
        {
            _context = context;
            _stockRepository = stockRepository;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockRepository.GetAllAsync();

            var StockDto = stocks.Select(s => s.ToStockDto());

            return Ok(StockDto);
        }


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var stock =await _stockRepository.GetByIdAsync(id);

            if (stock is null)
                return NotFound();

            return Ok(stock.ToStockDto());
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDTO();

          await _stockRepository.CreateAsync(stockModel);

            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());

            //new
            //{
            //    success_notification = "Add Brand Successfully"
            //}
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, UpdateStockRequestDto updateDto)
        {
            var stockModel =await _stockRepository.UpdateAsync(id, updateDto);

            if (stockModel is null)
                return NotFound();


           // stockModel.Symbol = updateDto.Symbol;
           // stockModel.CompanyName = updateDto.CompanyName;
           // stockModel.Purchase = updateDto.Purchase;
           // stockModel.MarketCap = updateDto.MarketCap;
           // stockModel.Industry = updateDto.Industry;
           // stockModel.LastDiv = updateDto.LastDiv;

           //await _context.SaveChangesAsync();

            return Ok(stockModel.ToStockDto());
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var stockModel =await _stockRepository.DeleteAsync(id);

            if (stockModel is null)
                return NotFound();

            return NoContent();
        }

    }
}
