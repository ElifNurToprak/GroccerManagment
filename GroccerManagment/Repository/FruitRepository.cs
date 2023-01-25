using GroccerManagment.DataAccessLayer;
using GroccerManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroccerManagment.Repository
{
    internal class FruitRepository : IGenericRepository<Fruit>
    {
        DataContext db = new DataContext();
        public bool Add(Fruit entity)
        {
            bool status = false;
            try
            {
                db.Fruit.Add(entity);
                db.SaveChanges();

                status = true;
            }
            catch
            {
                status = false;
            }
            return status;

        }

        public bool Delete(int id)
        {
            bool status = false;
            var fruit = db.Fruit.Find(id);
            if (fruit != null)
            {
                fruit.IsDelete = true;
                db.SaveChanges();
                status = true;
            }
            return status;
        }

        public Fruit Detail(int id)
        {
            bool status = false;
            var fruit = db.Fruit.Find(id);

            return fruit;
        }

        public bool Edit(Fruit entity)
        {
            bool status = false;
            var fruit = db.Fruit.Find(entity.Id);
            if (fruit != null)
            {
                fruit = entity;
                db.SaveChanges();
                status = true;
            }
            return status;
        }

        public List<Fruit> List()
        {
            return db.Fruit.Where(x => x.IsDelete == false).ToList();
        }
    }
}
