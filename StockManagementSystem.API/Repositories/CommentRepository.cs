using Microsoft.EntityFrameworkCore;
using StockManagementSystem.API.DataAccess;
using StockManagementSystem.API.Models;
using StockManagementSystem.API.Repositories.IRepositories;

namespace StockManagementSystem.API.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }
    }
}
