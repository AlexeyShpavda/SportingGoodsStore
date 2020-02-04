using System.Linq;

namespace SportingGoodsStore.WebApp.Models.Interfaces
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }

        void SaveOrder(Order order);
    }
}
