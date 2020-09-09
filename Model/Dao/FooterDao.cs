using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class FooterDao
    {
        ShopDbContext db = null;
        public FooterDao()
        {
            this.db = new ShopDbContext();
        }
        public Footer GetFooter(String id)
        {
            return db.Footers.Where(x=>x.ID==id).SingleOrDefault(x => x.Status == true);
        }
    }
}
