using System.Collections.Generic;

namespace series_catalog
{
    public interface IRepository<T>
    {
        void insert(T obj);
        T getById(int id);
        void update(int id, T obj);
        void deleteById(int id);
        List<T> listAll();
        int lastId();
    }
}
