using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderB>> GetOrders();
        Task<OrderB> GetOrder(int orderId);
        Task<OrderB> AddOrder(OrderB order);
        Task<OrderB> UpdateOrder(OrderB order);
        Task<OrderB> DeleteOrder(int orderId);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly BookStoredbContext bookStoredbContext;
        
        public OrderRepository(BookStoredbContext bookStoredbContext)
        {
            this.bookStoredbContext = bookStoredbContext;



        }

        public async Task<OrderB> AddOrder(OrderB order)
        {
            var result = await bookStoredbContext.OrderBs.AddAsync(order);
            await bookStoredbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<OrderB> DeleteOrder(int orderId)
        {
            var result = await bookStoredbContext.OrderBs
          .FirstOrDefaultAsync(e => e.OrderId == orderId);
            if (result != null)
            {
                bookStoredbContext.OrderBs.Remove(result);
              
                await bookStoredbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }

        public async Task<OrderB> GetOrder(int orderId)
        {
            return await bookStoredbContext.OrderBs.Include(b => b.OrderB_Details).ThenInclude(od => od.Book)
               .FirstOrDefaultAsync(e => e.OrderId == orderId);
        }

        public async Task<IEnumerable<OrderB>> GetOrders()
        {
            var result = await bookStoredbContext.OrderBs.Include(b => b.OrderB_Details).ThenInclude(bbts => bbts.Book).ToListAsync();
            return result;
        }

        public async Task<OrderB> UpdateOrder(OrderB order)
        {
            var result = await bookStoredbContext.OrderBs
                 .FirstOrDefaultAsync(e => e.OrderId == order.OrderId);

            if (result != null)
            {
                ///  result = mapper.Map<Book>(book);
                result.OrderStatus = order.OrderStatus;
                result.OrderDate = order.OrderDate;
                result.TotalPrice = order.TotalPrice;
                
                await bookStoredbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }

}
