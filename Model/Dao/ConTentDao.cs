using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ConTentDao
    {
        ShopDbContext db = null;
        public ConTentDao()
        {
            this.db = new ShopDbContext();
        }
        public long Insert(ConTent entity)
        {
            db.ConTents.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public ConTent GetById(long id)
        {
            return db.ConTents.Find(id);
        }
    }
}
