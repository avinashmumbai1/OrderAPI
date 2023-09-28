﻿using AutoMapper;
using OrderApi.Application.DTOs;
using OrderApi.Domain.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrderDto>();
        CreateMap<OrderDto, Order>();
        CreateMap<OrderItem, OrderItem>();
        // Add more mappings as needed
    }
}