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
        IProductRepository _iproductRepository;
        public OrderService(IOrderRepository iorderRepository, IProductRepository iproductRepository)
        {
            _iorderRepository = iorderRepository;
            _iproductRepository = iproductRepository;
        }

        public async  Task<Order> Post(Order order)
        {
         
            bool checkSum = await CheckOrderSum(order);
            if (checkSum)
            {
                  return  await _iorderRepository.Post(order);
            }
            else
            {
                return null;
            }
            }
             

        public async Task<Order> GetById(int id)
        {
            return await _iorderRepository.GetById(id);
        }


        public async Task<bool> CheckOrderSum(Order order)
        {
            int sum = 0;
            foreach (var item in order.OrderItems)
            {
                Product p = await _iproductRepository.GetById(item.ProductId);
                sum += p.Price;
            }
            if (sum == order.OrderSum)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
       

    }
}
