using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {

        IOrderRepository _iorderRepository;

        public OrderService(IOrderRepository iorderRepository)
        {
            _iorderRepository = iorderRepository;
        }

        public Task<Order> Post(Order order)
        {
            return _iorderRepository.Post(order);
        }

        public async Task<Order> GetById(int id)
        {
            return await _iorderRepository.GetById(id);
        }

    }
}
