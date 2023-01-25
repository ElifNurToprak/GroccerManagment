using GroccerManagment.DataAccessLayer;
using GroccerManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroccerManagment.Repository
{
    internal class VegetableRepository : IGenericRepository<Vegetable>
    {
        DataContext db = new DataContext();
        public bool Add(Vegetable entity)
        {
            bool status = false;
            try
            {
                db.Vegetable.Add(entity);
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
            var vegetable = db.Vegetable.Find(id);
            if (vegetable != null)
            {
                vegetable.IsDelete = true;
                db.SaveChanges();
                status = true;
            }
            return status;
        }

        public Vegetable Detail(int id)
        {
            bool status = false;
            var vegetable = db.Vegetable.Find(id);

            return vegetable;
        }

        public bool Edit(Vegetable entity)
        {
            bool status = false;
            var vegetable = db.Vegetable.Find(entity.Id);
            if (vegetable != null)
            {
                vegetable = entity;
                db.SaveChanges();
                status = true;
            }
            return status;
        }

        public List<Vegetable> List()
        {
            return db.Vegetable.Where(x => x.IsDelete == false).ToList();
        }
    }
}
