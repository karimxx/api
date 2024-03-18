using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        public readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }
        public  async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(p=>p.ProductBrand).Include(p => p.ProductTYPE).FirstOrDefaultAsync(p=> p.Id==id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();   
        }

        public Task<IReadOnlyList<ProductBrand>> GetProductsBrandsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ProductType>> GetProductsTypeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
