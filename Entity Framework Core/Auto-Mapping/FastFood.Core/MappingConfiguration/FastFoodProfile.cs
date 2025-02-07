﻿using FastFood.Core.ViewModels.Categories;
using FastFood.Core.ViewModels.Employees;
using FastFood.Core.ViewModels.Items;
using FastFood.Core.ViewModels.Orders;

namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Models;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Employee
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId,
                    y =>
                        y.MapFrom(s => s.Id));

            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position,
                    y =>
                        y.MapFrom(x =>
                        x.Position.Name));

            //Category
            this.CreateMap<Category, CategoryAllViewModel>();

            //Items
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x =>
                    x.CategoryId, y =>
                    y.MapFrom(x => x.Id));

            this.CreateMap<CreateItemViewModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>();

            //Order
            this.CreateMap<CreateOrderInputModel, Order>();

           
        }
    }
}
