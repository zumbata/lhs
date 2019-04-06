using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class UsersBusiness
    {
        private DBContext dbContext;
        public List<User> GetAll()
        {
            using (dbContext = new DBContext())
            {
                return dbContext.Users.ToList();
            }
        }
        public List<User> Get(string category)
        {
            using (dbContext = new DBContext())
            {
                Category cat = dbContext.Categories.Where(item => item.Name == category).First();
                return dbContext.Users.Where(item => item.CategoryId == cat.Id && item.FirstName != null && item.LastName != null).ToList();
            }
        }
        public User GetUser(int id)
        {
            using (dbContext = new DBContext())
            {
                return dbContext.Users.Find(id);
            }
        }
        public User GetUser(string str)
        {
            using (dbContext = new DBContext())
            {
                try
                {
                    User user = dbContext.Users.Where(item => item.Username == str).First();
                    return dbContext.Users.Where(item => item.Id == user.Id).First();
                }
                catch(Exception e)
                {
                    return null;
                }
                
            }
        }
        public Category GetCategory(int id)
        {
            using (dbContext = new DBContext())
            {
                return dbContext.Categories.Find(id);
            }
        }
        public void Update(User user)
        {
            using (dbContext = new DBContext())
            {
                var item = dbContext.Users.Find(user.Id);
                if (item != null)
                {
                    dbContext.Entry(item).CurrentValues.SetValues(user);
                    dbContext.SaveChanges();
                }
            }
        }

    }
}
