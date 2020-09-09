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
         public IEnumerable<ConTent> ListAll( int page, int pageSize)
        {
            IQueryable<ConTent> model = db.ConTents;
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
    }
}
