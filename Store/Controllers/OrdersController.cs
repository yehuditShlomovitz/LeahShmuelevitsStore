using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IMapper _imapper;
        IOrderService _iorderService;
        private readonly ILogger<UsersController> _logger;
        public OrdersController(IOrderService iorderService,IMapper imapper, ILogger<UsersController> logger)
        {
            _logger = logger;
            _imapper = imapper;
            _iorderService = iorderService;
        }


        // GET api/<OrdersController>/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Order>> Get(int id)
        //{
        //    Order order=await _iorderService.GetById(id);
        //   if(order==null)
        //        return NoContent();
        //    return Ok(order);

        //}






        // POST api/<OrdersController>
        //[HttpPost]
        //public async Task<ActionResult<Order>> Post([FromBody] Order order)
        //{
        //    Order order1 = await _iorderService.Post(order);

        //    if (order1 == null)
        //        return NoContent();
        //    return Ok(order1);
        //}

        //public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO order)
        //{

        //    Order order1= _imapper.Map<OrderDTO, Order>(order);
        //    await _iorderService.Post(order1);
        //    if (order1 == null)
        //        return NoContent();
        //    return Ok(order1);
        //}

        [HttpPost]
        public async Task<ActionResult<GetOrderDTO>> Post([FromBody] OrderDTO order)
        {

            Order order1 = _imapper.Map<OrderDTO, Order>(order);

            Order check = await _iorderService.Post(order1);

            if (check!=null)
            {   
                GetOrderDTO order2 = _imapper.Map<Order, GetOrderDTO>(order1);
             return Ok(order2);
            }
            else
            {
                _logger.LogInformation($"{order.UserId} try to change the sum of the order!!!");
                return Unauthorized();
            }
           
            
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {
            Order order = await _iorderService.GetById(id);
            GetOrderDTO orderDTO = _imapper.Map<Order, GetOrderDTO>(order);
            if (orderDTO == null)
                return NoContent();
            return Ok(orderDTO);

        }

    
    }
}
