
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Text.Json;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ManagerDbContext _ManagerDbContext;

        public ProductRepository(ManagerDbContext managerDbContext)
        {
            _ManagerDbContext = managerDbContext;
        }

      
        public async Task<List<Product>> Get(string? desc, int?minPrice,int? maxPrice, int?[]categoryIds)
        {
            var query=_ManagerDbContext.Products.Where(product=>
            (desc==null ? (true):(product.Description.Contains(desc)))
            &&((minPrice == null) ? (true) : (product.Price>=minPrice))
            &&((maxPrice == null) ? (true) : (product.Price<=maxPrice))
            &&((categoryIds.Length == 0) ? (true) :(categoryIds.Contains(product.CategoryId))))
                .OrderBy(product => product.Price);
            Console.WriteLine(query.ToQueryString());
            List<Product>products=await query.Include(p => p.Category).ToListAsync();
            return products;
            // return  await _ManagerDbContext.Products.Include(p=>p.Category).ToListAsync();

        }

        public async Task<Product> GetById(int id)
        {
            return await _ManagerDbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
