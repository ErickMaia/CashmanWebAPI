using System.Collections.Generic;
using System.Data;
using Cashman.BLL.Interfaces;
using Microsoft.Extensions.Configuration; 
using MySqlConnector; 

namespace Cashman.DAL.Repository
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected readonly IConfiguration _configuration;
        protected readonly IDbConnection _connection; 
        
        public Repository(IConfiguration configuration)
        {
            _connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public abstract bool Add(T entity);
        public abstract IEnumerable<T> Get();
        public abstract T GetById(int id);
        public abstract bool Remove(int id);
        public abstract bool Update(T entity);
    }
}