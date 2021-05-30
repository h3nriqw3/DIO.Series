using System.Collections.Generic;

namespace DIO.CrudSeries.Interfaces
{
    public interface IRepository<T>
    {
         List<T> ListSeries();
         T GetById(int id);
         void Create(T obj);
         void Remove(int id);
         void Update(int id, T obj);
         int NextId();
    }
}