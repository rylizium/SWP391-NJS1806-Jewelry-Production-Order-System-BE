using AutoMapper;
using Repositories.Dto;
using Repositories.Models;
using System.Numerics;
using System.Runtime.CompilerServices;


namespace Repositories.Helper
{

    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Design, DesignDto>();
            CreateMap<DesignDto, Design>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<OrderCustomItem, OrderCuSDto>();
            CreateMap<OrderCuSDto, OrderCustomItem>();

            CreateMap<OrderFixedItem, OrderFixedItemDto>();
            CreateMap<OrderFixedItemDto, OrderFixedItem>();
            CreateMap<OrderFixedItemStock, OrderFixedItem>();

            CreateMap<OrderFixedItem, OrderFixedItemStock>();
            CreateMap<OrderFixedItemStock, OrderFixedItem>();

            CreateMap<PaymentStatus, PaymentStatusDto>();
            CreateMap<PaymentStatusDto, PaymentStatus>();

            CreateMap<Order, OrderStockDto>();
            CreateMap<OrderStockDto, Order>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductStock, ProductStockDto>();
            CreateMap<Gemstone, GemstoneDto>();
    

            CreateMap<Status, StatusDto>();
            

        }
    }
}
