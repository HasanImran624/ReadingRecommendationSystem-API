using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Koinz.DataProvider.EFCore.Context
{
    public class ReadingRecommendationDBContext<T>: ReadingRecommendationBaseDBContext where T : class
    {

        public int Id { get; set; }

        public DbSet<T> entities { get; set; }

        public int Save(T obj)
        {
            entities.Add(obj);
            return SaveChanges();
        }
        public async Task<int> SaveAsync(T obj)
        {
            entities.Add(obj);
            return await SaveChangesAsync();
        }
        public int Save(List<T> objList)
        {
            entities.AddRange(objList);
            return SaveChanges();
        }

        public virtual void Update(T currentobj, T modifiedobj)
        {
            Entry(currentobj).CurrentValues.SetValues(modifiedobj);
            SaveChanges();
        }

        public virtual void Update()
        {
            SaveChanges();
        }
        public int BulkSave(List<T> obj)
        {
            entities.AddRange(obj);
            return SaveChanges();
        }

        public int BulkUpdate()
        {
            return SaveChanges();
        }
        public int BulkRemove(List<T> obj)
        {
            entities.RemoveRange(obj);
            return SaveChanges();
        }
        public int Remove(T obj)
        {
            entities.Remove(obj);
            return SaveChanges();
        }
    }
}
