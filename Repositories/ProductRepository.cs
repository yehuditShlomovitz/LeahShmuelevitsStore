
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

      
        public async Task<List<Product>> Get()
        {
          return  await _ManagerDbContext.Products.Include(p=>p.Category).ToListAsync();
             
        }
    
    }
}
