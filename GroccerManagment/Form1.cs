using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroccerManagment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fruitBtn_Click(object sender, EventArgs e)
        {
            FruitProccess fruitProccess = new FruitProccess();
            fruitProccess.Show();
        }

        private void vegetableBtn_Click(object sender, EventArgs e)
        {
            VegetableProccess vegetableProccess = new VegetableProccess();
            vegetableProccess.Show();
        }
    }
}
