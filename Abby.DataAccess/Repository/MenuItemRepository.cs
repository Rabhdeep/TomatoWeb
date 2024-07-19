using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abby.DataAccess.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDBContext _db;
        public MenuItemRepository(ApplicationDBContext db):base(db)
        {
            _db = db;
        }


        public void Update(MenuItem menuItem)
        {
            var objFromDb = _db.MenuItem.FirstOrDefault(u => u.Id == menuItem.Id);
            objFromDb.Name = menuItem.Name;
            objFromDb.Description = menuItem.Description;
            objFromDb.Price = menuItem.Price;
            objFromDb.CategoryId= menuItem.CategoryId;
            objFromDb.FoodTypeId =menuItem.FoodTypeId;
            if(objFromDb.Image!=null)
            {
                objFromDb.Image=menuItem.Image;
            }

        }
    }
}
