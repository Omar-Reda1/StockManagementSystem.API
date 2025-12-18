using StockManagementSystem.API.Models;

namespace StockManagementSystem.API.Repositories.IRepositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
    }
}
