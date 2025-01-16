using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record  ProductDTO(int id,string? CategoryCategoryName,string ProductName,int Price,string? Image, string? Description);
    
}
