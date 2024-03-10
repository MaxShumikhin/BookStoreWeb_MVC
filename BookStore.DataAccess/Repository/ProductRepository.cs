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
        _context.Products.Update(product);
    }
}