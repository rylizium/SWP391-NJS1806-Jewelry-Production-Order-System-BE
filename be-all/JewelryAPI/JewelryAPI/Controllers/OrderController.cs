using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Repositories.Dto;
using Repositories.Models;
using Services;

namespace JewelryAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly PaymentStatusService _paymentStatus;
        private readonly StatusService _status;
        private readonly OrderService _order;
        private readonly IMapper _mapper;

        public OrderController(PaymentStatusService paymentStatus, StatusService status, OrderService order, IMapper mapper)
        {

            _paymentStatus = paymentStatus;
            _status = status;
            _order = order;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllOrders()
        {
            var orders = _mapper.Map<List<OrderDto>>(_order.GetAllOrders());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(orders);
        }
        [HttpGet("{orderId}")]
        [ProducesResponseType(200, Type = typeof(OrderDto))]
        [ProducesResponseType(400)]
        public IActionResult GetOrderById(int orderId)
        {
            var order = _mapper.Map<OrderDto>(_order.GetOrderById(orderId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(order);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddOrder([FromBody] OrderStockDto orderStock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (orderStock == null)
            {
                return BadRequest();
            }
          
            var order = _mapper.Map<Order>(orderStock);

            int paymentId = order.PaymentStatusId;
            int statusId = order.StatusId;
            

            order.PaymentStatus = _paymentStatus.GetPaymentStatusById(paymentId);
            order.Status = _status.GetStatusById(statusId);

            if (!_order.AddOrder(order))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return CreatedAtAction("GetOrderById", new { orderId = order.OrderId }, orderStock);


        }
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdatedOrder([FromBody] OrderStockDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var order = _mapper.Map<Order>(orderDto);
            if (!_order.UpdateOrder(order))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult DeleteOrder(int orderId)
        {
            var orders = _order.GetOrderById(orderId);
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             if (orders == null)
            {
                return NotFound();
            }

            if (!_order.DeleteOrder(orders))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }
            return NoContent();


        }
    }
}

