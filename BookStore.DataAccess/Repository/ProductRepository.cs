using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using BookStoreWeb.DataAccess.Data;

namespace BookStore.DataAccess.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Product product)
    {
        var objFromDb = _context.Products.FirstOrDefault(o => o.Id == product.Id);
        if (objFromDb != null)
        {
            objFromDb.Title  = product.Title;
            objFromDb.ISBN  = product.ISBN;
            objFromDb.Price  = product.Price;
            objFromDb.Price50  = product.Price50;
            objFromDb.Price100  = product.Price100;
            objFromDb.ListPrice  = product.ListPrice;
            objFromDb.Description  = product.Description;
            objFromDb.CategoryId = product.CategoryId;
            objFromDb.Author  = product.Author;

            if (product.ImageUrl != null)
            {
                objFromDb.ImageUrl = product.ImageUrl;
            }
        }
    }
}