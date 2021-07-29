using System.Collections.Generic;

namespace series_catalog
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> lista = new List<Serie>();

        // Métodos do CRUD

        public void insert(Serie obj)
        {
            lista.Add(obj);
        }

        public Serie getById(int id)
        {
            return lista[id];
        }

        public void update(int id, Serie obj)
        {
            lista[id] = obj;
        }

        public void deleteById(int id)
        {
            lista[id].excluir();
        }

        // Outros métodos

        public List<Serie> listAll()
        {
            return lista;
        }

        public int lastId()
        {
            return lista.Count;
        }
    }
}
