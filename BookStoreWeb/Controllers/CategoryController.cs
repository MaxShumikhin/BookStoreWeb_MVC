using BookStoreWeb.Data;
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
    }
}
