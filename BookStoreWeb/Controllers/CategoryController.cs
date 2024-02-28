﻿using BookStoreWeb.Data;
using BookStoreWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        public CategoryController(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var categoryList = _appDbContext.Categories.ToList();
            return View(categoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order can't exactly match the name");
            }

            if (ModelState.IsValid)
            {
                _appDbContext.Categories.Add(category);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
