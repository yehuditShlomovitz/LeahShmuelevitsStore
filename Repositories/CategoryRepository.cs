using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using System.Text.Json;
namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ManagerDbContext _ManagerDbContext;
        public CategoryRepository(ManagerDbContext managerDbContext)
        {
            _ManagerDbContext = managerDbContext;
        }


        public async Task<List<Category>> Get()
        {
            return await _ManagerDbContext.Categories.ToListAsync();

        }

    }
}







