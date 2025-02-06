using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context=context;
        }
        public async Task<List<Stock>> GetAllAsync()
        {
           return await _context.Stocks.Include(c=>c.Comments).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(c=>c.Comments).FirstOrDefaultAsync(s=>s.Id == id);
        }
        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> UpdateAsync(int id, Stock stockModel)
        {
            var existingStock = await _context.Stocks.FindAsync(id);
            if(existingStock == null) return null;

            existingStock.Symbol = stockModel.Symbol;
            existingStock.CompanyName = stockModel.CompanyName;

            await _context.SaveChangesAsync();
            return existingStock;
    
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var existingStock = await _context.Stocks.FindAsync(id);
            if(existingStock == null) return null;

            _context.Stocks.Remove(existingStock);
            await _context.SaveChangesAsync();
            return existingStock;
    
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stocks.AnyAsync(s=>s.Id==id);
        }
    }
}