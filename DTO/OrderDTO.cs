using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record  OrderDTO(DateOnly OrderDate,float OrderSum,int UserId,List<OrderItemDTO>OrderItems);
    public record GetOrderDTO(int Id,DateOnly OrderDate, float OrderSum, string UserUserName, List<OrderItemDTO> OrderItems);


}
