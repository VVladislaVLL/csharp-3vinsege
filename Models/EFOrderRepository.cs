using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SportsStore.Models
{
    public class EfOrderRepository : IOrderRepository
    {
        private StoreDbContext context;

        public EfOrderRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Order> Orders => context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.CourseWork);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.CourseWork));
            if (order.OrderId == 0)
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();
        }
    }
}