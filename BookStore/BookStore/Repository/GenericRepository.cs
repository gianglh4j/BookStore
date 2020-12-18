using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> Get(int? id);
        IEnumerable<T> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);

    }
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly BookStoredbContext _bookStoredbContext;
        private DbSet<T> _dbset;
        string errorMessage = string.Empty;
        public GenericRepository(BookStoredbContext bookStoredbContext)
        {
            _bookStoredbContext = bookStoredbContext;
            _dbset = _bookStoredbContext.Set<T>();
        }

        public async Task Add(T entity)
        {
            _dbset.Add(entity);
            await _bookStoredbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbset.Remove(entity);
            await _bookStoredbContext.SaveChangesAsync();
        }



        public async Task Update(T entity)
        {
            _dbset.Update(entity);
            await _bookStoredbContext.SaveChangesAsync();

        }

        public async Task<T> Get(int? id)
        {
            var idName = _bookStoredbContext.Model.FindEntityType(typeof(T))
               .FindPrimaryKey().Properties.Single().Name;
    
            return await _dbset.SingleOrDefaultAsync(s => (int)s.GetType().GetProperty(idName).GetValue(s, null) == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable();
        }

    }
}
