using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {

        ICategoryRepository _icategoryRepository;

        public CategoryService(ICategoryRepository icategoryRepository)
        {
            _icategoryRepository = icategoryRepository;
        }

        

        public async Task<List<Category>> Get()
        {
            return await _icategoryRepository.Get();
        }

    }


}
