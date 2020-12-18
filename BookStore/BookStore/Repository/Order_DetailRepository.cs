using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Data;

namespace BookStore.Repository
{
    public interface IOrder_DetailRepository
    {
        Task<IEnumerable<OrderB_Detail>> GetOrderB_Details();
        Task<OrderB_Detail> GetOrderB_Detail(int OrderB_DetailId);
        Task<OrderB_Detail> AddOrderB_Detail(OrderB_Detail orderB_Detail);
        Task<OrderB_Detail> UpdateOrderB_Detail(OrderB_Detail OrderB_Detail);
        Task<OrderB_Detail> DeleteOrderB_Detail(int OrderB_DetailId);

    }
    public class Order_DetailRepository : IOrder_DetailRepository
    {
        private readonly BookStoredbContext bookStoredbContext;
        public Order_DetailRepository(BookStoredbContext bookStoredbContext)
        {
            this.bookStoredbContext = bookStoredbContext;

        }
        public async Task<OrderB_Detail> AddOrderB_Detail(OrderB_Detail orderB_Detail)
        {
            var result = await bookStoredbContext.OrderB_Details.AddAsync(orderB_Detail);
            try
            {
                await bookStoredbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return result.Entity;
        }

        public Task<OrderB_Detail> DeleteOrderB_Detail(int OrderB_DetailId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderB_Detail> GetOrderB_Detail(int OrderB_DetailId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderB_Detail>> GetOrderB_Details()
        {
            throw new NotImplementedException();
        }

        public Task<OrderB_Detail> UpdateOrderB_Detail(OrderB_Detail OrderB_Detail)
        {
            throw new NotImplementedException();
        }
    }
}
