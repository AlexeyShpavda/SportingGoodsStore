using System.Linq;

namespace SportingGoodsStore.WebApp.Models.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productID);
    }
}
