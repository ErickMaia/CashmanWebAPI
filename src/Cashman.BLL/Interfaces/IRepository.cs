using System.Collections.Generic;

namespace Cashman.BLL.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get(); 
        T GetById(int id); 
        bool Add(T entity);
        bool Update(T entity); 
        bool Remove(int id); 
    }
}