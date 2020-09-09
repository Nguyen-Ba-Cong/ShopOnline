using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model.EF;
using PagedList;
namespace Model.Dao
{
    public class UserDao
    {
        ShopDbContext db = null;
        public UserDao()
        {
            db = new ShopDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public int Login(String UserName, String Password)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == UserName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == Password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }

            }

        }
        public List<String> GetListCredential(String userName)
        {
            var user = db.Users.Single(x => x.UserName == userName);
            var data = (from a in db.Credentials
                        join b in db.UserGroups on a.UserGroupID equals b.ID
                        join c in db.Roles on a.RoleID equals c.ID
                        select new 
                        {
                            UserGroupID = a.UserGroupID,
                            RoleID = a.RoleID
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
                       
            return data.Select(x => x.RoleID).ToList();

        }
        public int Login(String UserName, String Password, bool isLoginAdmin = false)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == UserName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if ((result.GroupID == CommonConstants.ADMIN_GROUP || result.GroupID == CommonConstants.MOD_GROUP))
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == Password)
                            {
                                return 1;
                            }
                            else
                            {
                                return -2;
                            }
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == Password)
                        {
                            return 1;
                        }
                        else
                        {
                            return -2;
                        }
                    }
                }
            }

        }
        public User FindByID(String UserName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == UserName);
        }
        public User ViewDetail(int ID)
        {
            return db.Users.Find(ID);
        }
        public IEnumerable<User> ListAll(String SearchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!String.IsNullOrEmpty(SearchString))
            {
                model = model.Where(x => x.UserName.Contains(SearchString) || x.Name.Contains(SearchString) || x.Address.Contains(SearchString) || x.Phone.Contains(SearchString));
            }
            return model.OrderByDescending(x => x.CreatedDay).ToPagedList(page, pageSize);
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                if (!String.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Name = entity.Name;
                user.Address = entity.Address;
                user.Phone = entity.Phone;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDay = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool CheckName(String usernName)
        {
            return db.Users.Count(x => x.UserName == usernName) > 0;
        }
        public bool CheckEmail(String email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
    }
}
