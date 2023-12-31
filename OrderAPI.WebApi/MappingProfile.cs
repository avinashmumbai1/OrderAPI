﻿using AutoMapper;
using OrderApi.Application.DTOs;
using OrderApi.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<OrderApi.Domain.Entities.Order, OrderDto>();
        CreateMap<OrderDto, Order>();
        CreateMap<OrderItem, OrderItem>();
        CreateMap<Customer, CustomerDto>();
        // Add more mappings as needed
    }
}
