using GroccerManagment.DataAccessLayer;
using GroccerManagment.Models;
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
    public partial class FruitProccess : Form
    {
        DataContext db = new DataContext();
        string ImageFolder = @"C:\Users\Elif\Desktop\GroccerManagment\GroccerManagment\GroccerManagment\Images";
        string addFruitImage = "";
        int i = 0;
        string editFruitImageName = "";
        string editSelectImageName = "";
        int editFruitId = 0;
        public FruitProccess()
        {
            InitializeComponent();
        }

        private void addVegetableBtn_Click(object sender, EventArgs e)
        {
            Fruit fruit = new Fruit();

            
            
            fruit.Name = addVegetableNameTxt.Text;

            fruit.Quantity = Convert.ToInt32(addQuantityTxt.Text);

            fruit.IsStatus = addStatusChb.Checked;

            fruit.Image = addFruitImage;

            fruit.Barcode= barcodeTxt.Text;

            try
            {

                db.Fruit.Add(fruit);
                db.SaveChanges();
            }
            catch
            { }
            GetData();

        }

        private void DeleteVegetableBtn_Click(object sender, EventArgs e)
        {
            //i = Convert.ToInt32(deleteFruitIdTxt.Text);
            //var fruit = db.Fruit.Where(x => x.Id == i).FirstOrDefault();

            string o = barcodeTxttt.Text;
            var fruitbarcod = db.Fruit.Where(x => x.Barcode == o).FirstOrDefault();
            if (fruitbarcod != null)
            {
                MessageBox.Show(deleteFruitDgw.CurrentRow.Cells[1].Value.ToString() + " Fruit Deleted",
                                 "Delete Fruit",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);


            }
            else
            {

                MessageBox.Show("Not Found Fruit",
                                "Delete Fruit",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }


            //if (fruit != null)
            //{
            //    MessageBox.Show(deleteFruitDgw.CurrentRow.Cells[1].Value.ToString() + " Fruit Deleted",
            //                     "Delete Fruit",
            //                     MessageBoxButtons.OK,
            //                     MessageBoxIcon.Information);


            //}
            //else
            //{

            //    MessageBox.Show("Not Found Fruit",
            //                    "Delete Fruit",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Warning);
            //}
            //db.Fruit.Remove(fruit);
            db.Fruit.Remove(fruitbarcod);
            db.SaveChanges();
            GetData();
        }

        private void editVegetableBtn_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = new DialogResult();

            var editColumn = db.Fruit.Where(x => x.Id == editFruitId).FirstOrDefault();

            dialogResult = MessageBox.Show("Do you edit the Fruit?", "Fruit",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes && editColumn == null)
            {
                Fruit fruit = new Fruit();
                fruit.Barcode = barcodeTxt.Text;

                fruit.Name = editFruitNameTxt.Text;

                fruit.Quantity = Convert.ToInt32(editFruitQuantityTxt.Text);

                fruit.IsStatus = editFruitStatusCheck.Checked;

                fruit.Image = editFruitImageName;



                if (editFruitImageName == "")
                {
                    fruit.Image = editSelectImageName;
                }
                else
                {
                    fruit.Image = editFruitImageName;
                    editFruitImagePb.Image.Save(ImageFolder + editFruitImageName);
                }
                db.Fruit.Add(fruit);
                db.SaveChanges();
            }
            else if (dialogResult == DialogResult.Yes && editColumn != null)
            {
                
                editColumn.Name = editFruitNameTxt.Text;

                editColumn.Barcode = barcodeTxt.Text;

                editColumn.Quantity = Convert.ToInt32(editFruitQuantityTxt.Text);

                editColumn.IsStatus = editFruitStatusCheck.Checked;


                if (editFruitImageName == "")
                {
                    editColumn.Image = editSelectImageName;
                }
                else
                {
                    editColumn.Image = editFruitImageName;
                    editFruitImagePb.Image.Save(ImageFolder + editFruitImageName);
                }
                db.SaveChanges();

            }
            GetData();
        }

        private void editVegetableImagePb_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                editFruitImagePb.ImageLocation = openFileDialog.FileName;
                string[] ImageName = openFileDialog.FileName.ToString().Split('\\');
                editFruitImageName = Guid.NewGuid().ToString() + "-" + ImageName[ImageName.Length - 1].ToString();


            }
            else
            {
                MessageBox.Show("Seçim Başarısız");
                editFruitImageName = "";
            }
        }

        private void editFruitDgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Fruit fruit = new Fruit();
            editFruitId = Convert.ToInt32(editFruitDgw.CurrentRow.Cells[0].Value);
            editFruitNameTxt.Text = editFruitDgw.CurrentRow.Cells[1].Value.ToString();
            editFruitQuantityTxt.Text = editFruitDgw.CurrentRow.Cells[3].Value.ToString();
            editFruitStatusCheck.Checked = Convert.ToBoolean(editFruitDgw.CurrentRow.Cells[4].Value);
            editFruitImagePb.ImageLocation = ImageFolder + editFruitDgw.CurrentRow.Cells[2].Value.ToString();

            db.Fruit.Add(fruit);
            db.SaveChanges();
        }

        private void FruitProccess_Load(object sender, EventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            // addVegetableListDgw.DataSource = db.Participant.ToList();
           addFruitDgw.DataSource = db.Fruit.ToList();
            editFruitDgw.DataSource = db.Fruit.ToList();
            deleteFruitDgw.DataSource = db.Fruit.ToList();

        }

        private void addVegetablePb_Click(object sender, EventArgs e)
        {
             OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                addVegetablePb.ImageLocation = openFileDialog.FileName;
                string[] imageName = openFileDialog.FileName.ToString().Split('\\');
                addFruitImage = Guid.NewGuid().ToString() + "-" + imageName[imageName.Length - 1].ToString();

            }
            else
            {
                MessageBox.Show("Picture Selection Process Canceled.");
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barcodeTxttt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
