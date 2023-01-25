using GroccerManagment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroccerManagment.DataAccessLayer
{
    internal class DataContext : DbContext
    {
        public DataContext() : base("DbConnection") { }

        public DbSet<Fruit> Fruit { get; set; }
        public DbSet<Vegetable> Vegetable { get; set; }
    }
}