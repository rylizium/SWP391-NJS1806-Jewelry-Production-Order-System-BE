using AutoMapper;
using Repositories;
using Repositories.Models;

namespace Services;

public class OrderService
{
    private readonly IMapper _mapper;
    private OrderRepository _repository;
    public ICollection<Order> GetAllOrders()
    {
        _repository = new OrderRepository(_mapper);
        return _repository.GetAllOrders();
        
    }

    public Order GetOrderById(int orderId)
    {
        _repository = new OrderRepository(_mapper);
        return _repository.GetOrderById(orderId);
    }

    public bool AddOrder(Order order)
    {
        _repository = new OrderRepository(_mapper);
        return _repository.AddOrder(order);
    }

    public bool UpdateOrder(Order order)
    {
        _repository = new OrderRepository(_mapper);
        return _repository.UpdateOrder(order);
    }

    public bool DeleteOrder(Order orderId)
    {
        _repository = new OrderRepository(_mapper);
        return _repository.DeleteOrder(orderId);
    }
}
