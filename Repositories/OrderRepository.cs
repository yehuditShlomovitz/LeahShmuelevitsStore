using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {

        ManagerDbContext _ManagerDbContext;

        public OrderRepository(ManagerDbContext managerDbContext)
        {
            _ManagerDbContext = managerDbContext;
        }
        

        public async Task<Order> Post(Order order)
        {
            await _ManagerDbContext.Orders.AddAsync(order);
            await _ManagerDbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetById(int id)
        {
            return await _ManagerDbContext.Orders.Include(o=>o.User).Include(l=>l.OrderItems).FirstOrDefaultAsync(o => o.Id == id);
        }

    }

}

