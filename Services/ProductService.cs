using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository _iproductRepository;

        public ProductService(IProductRepository iproductRepository)
        {
            _iproductRepository = iproductRepository;
        }


        public async Task<List<Product>> Get()
        {
            return await _iproductRepository.Get();
        }

    }
}

