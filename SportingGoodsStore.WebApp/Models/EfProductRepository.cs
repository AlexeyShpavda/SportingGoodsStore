using SportingGoodsStore.WebApp.Models.Interfaces;
using System.Linq;

namespace SportingGoodsStore.WebApp.Models
{
    public class EfProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public EfProductRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public IQueryable<Product> Products => _context.Products;
    }
}
