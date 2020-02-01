using SportingGoodsStore.WebApp.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SportingGoodsStore.WebApp.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product { Name = "Football", Price = 25 },
            new Product { Name = "Surf board", Price = 179 },
            new Product { Name = "Running shoes", Price = 95 }
        }.AsQueryable();
    }
}
