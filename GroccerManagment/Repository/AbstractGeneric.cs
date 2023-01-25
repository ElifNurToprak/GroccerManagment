using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroccerManagment.Repository
{
    internal class AbstractGeneric
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDelete { get; set; }
    }
}
