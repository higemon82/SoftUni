﻿using System.Linq;
using AutoMapper.QueryableExtensions;
using FastFood.Models;

namespace FastFood.Core.Controllers
{
    using System;
    using AutoMapper;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public CategoriesController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            var category = new Category
            {
                Name = model.CategoryName,
            };

            this.context.Categories.Add(category);
            this.context.SaveChanges();

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var categories = context.Categories
                .ProjectTo<CategoryAllViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return this.View(categories);
        }
    }
}
