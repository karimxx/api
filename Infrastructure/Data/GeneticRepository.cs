using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class GeneticRepository<T> : IGeneticRepository<T> where T : BaseEntity
    {
        public readonly StoreContext _context;

        public GeneticRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);


        }

        public async Task<T> GetEnityWithSpec(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> spec)
        {
            return await ApplySpecifications(spec).ToListAsync();
        }

        private IQueryable<T> ApplySpecifications(ISpecifications<T> spec)
        {
            return SpecificationEvalutor<T>.GetQuery(_context.Set<T>(), spec);
        }
    }
}
