using System.Linq.Expressions;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using BookStoreWeb.DataAccess.Data;

namespace BookStore.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) :base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
