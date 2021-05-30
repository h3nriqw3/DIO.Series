using System.Collections.Generic;
using DIO.CrudSeries.Interfaces;

namespace DIO.CrudSeries.Classes
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> series = new List<Series>();
        public void Create(Series obj)
        {
            this.series.Add(obj);
        }

        public Series GetById(int id)
        {
            return this.series.Find(o => o.getId() == id && o.isDeleted() == false);
        }

        public List<Series> ListSeries()
        {
            return this.series.FindAll(o => o.isDeleted() == false);
        }

        public int NextId()
        {
            return this.series.Count;
        }

        public void Remove(int id)
        {
            this.series[id].remove();
        }

        public void Update(int id, Series obj)
        {
            this.series[id] = obj;
        }
    }
};