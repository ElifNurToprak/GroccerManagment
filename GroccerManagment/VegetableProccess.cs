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
    public partial class VegetableProccess : Form
    {
        DataContext db = new DataContext();
        string ImageFolder = @"C:\Users\Elif\Desktop\GroccerManagment\GroccerManagment\GroccerManagment\Images";
        string addVegetableImage = "";
        int i = 0;
        string editVegetableImageName = "";
        string editSelectImageName = "";
        int editVegetableId = 0;

        public VegetableProccess()
        {
            InitializeComponent();
        }

        private void addVegetableBtn_Click(object sender, EventArgs e)
        {
            Vegetable vegetable = new Vegetable();

            vegetable.Barcode = vegetablebarcod.Text;

            vegetable.Name = addVegetableNameTxt.Text;

            vegetable.Quantity = Convert.ToInt32(addQuantityTxt.Text);

            vegetable.IsStatus = addStatusChb.Checked;

            vegetable.Image = addVegetableImage;





            try
            {

                db.Vegetable.Add(vegetable);
                db.SaveChanges();
            }
            catch
            { }
            GetData();
        }

        private void DeleteVegetableBtn_Click(object sender, EventArgs e)
        {
            //i = Convert.ToInt32(deleteVegetableIdTxt.Text);
            //var vegetable = db.Vegetable.Where(x => x.Id == i).FirstOrDefault();


            //if (vegetable != null)
            //{
            //    MessageBox.Show(deleteVegetableDgw.CurrentRow.Cells[1].Value.ToString() + " Vegetable Deleted",
            //                     "Delete Vegetable",
            //                     MessageBoxButtons.OK,
            //                     MessageBoxIcon.Information);


            //}
            //else
            //{

            //    MessageBox.Show("Not Found Vegetable",
            //                    "Delete Vegetable",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Warning);
            //}
            string o = barcodeT.Text;
            var vegetablebarcod = db.Vegetable.Where(x => x.Barcode == o).FirstOrDefault();
            if (vegetablebarcod != null)
            {
                MessageBox.Show(deleteVegetableDgw.CurrentRow.Cells[1].Value.ToString() + " Vegetable Deleted",
                                 "Delete Vegetable",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);


            }
            else
            {

                MessageBox.Show("Not Found Vegetable",
                                "Delete Vegetable",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            db.Vegetable.Remove(vegetablebarcod);
            db.SaveChanges();
            GetData();

        }

        private void editVegetableBtn_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = new DialogResult();

            var editColumn = db.Vegetable.Where(x => x.Id == editVegetableId).FirstOrDefault();

            dialogResult = MessageBox.Show("Do you edit the Participant?", "Participant",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes && editColumn == null)
            {
                Vegetable vegetable = new Vegetable();

                vegetable.Barcode = barcodeTxtT.Text;

                vegetable.Name = editVegetableNameTxt.Text;

                vegetable.Quantity = Convert.ToInt32(editVegetableQuantityTxt.Text);

                vegetable.IsStatus = editVegetableStatusCheck.Checked;

                vegetable.Image = editVegetableImageName;



                if (editVegetableImageName == "")
                {
                    vegetable.Image = editSelectImageName;
                }
                else
                {
                    vegetable.Image = editVegetableImageName;
                    editVegetableImagePb.Image.Save(ImageFolder + editVegetableImageName);
                }
                db.Vegetable.Add(vegetable);
                db.SaveChanges();
            }
            else if (dialogResult == DialogResult.Yes && editColumn != null)
            {
                editColumn.Name = editVegetableNameTxt.Text;

                editColumn.Quantity = Convert.ToInt32(editVegetableQuantityTxt.Text);

                editColumn.IsStatus = editVegetableStatusCheck.Checked;


                if (editVegetableImageName == "")
                {
                    editColumn.Image = editSelectImageName;
                }
                else
                {
                    editColumn.Image = editVegetableImageName;
                    editVegetableImagePb.Image.Save(ImageFolder + editVegetableImageName);
                }
                db.SaveChanges();

            }
            GetData();
        }

        public void GetData()
        {
            // addVegetableListDgw.DataSource = db.Participant.ToList();
            addVegetableDgw.DataSource = db.Vegetable.ToList();

            editVegetableDgw.DataSource = db.Vegetable.ToList();

            
         deleteVegetableDgw.DataSource = db.Vegetable.ToList();

        }

        private void editVegetableImagePb_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                editVegetableImagePb.ImageLocation = openFileDialog.FileName;
                string[] ImageName = openFileDialog.FileName.ToString().Split('\\');
                editVegetableImageName = Guid.NewGuid().ToString() + "-" + ImageName[ImageName.Length - 1].ToString();


            }
            else
            {
                MessageBox.Show("Seçim Başarısız");
                editVegetableImageName = "";
            }
        }

        private void editVegetableDgw_DoubleClick(object sender, EventArgs e)
        {
            Vegetable vegetable = new Vegetable();
            editVegetableId = Convert.ToInt32(editVegetableDgw.CurrentRow.Cells[0].Value);
            editVegetableNameTxt.Text = editVegetableDgw.CurrentRow.Cells[1].Value.ToString();
            editVegetableQuantityTxt.Text = editVegetableDgw.CurrentRow.Cells[4].Value.ToString();
            editVegetableStatusCheck.Checked = Convert.ToBoolean(editVegetableDgw.CurrentRow.Cells[3].Value);
            editVegetableImagePb.ImageLocation = ImageFolder + editVegetableDgw.CurrentRow.Cells[2].Value.ToString();

            db.Vegetable.Add(vegetable);
            db.SaveChanges();
        }

        private void VegetableProccess_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void addVegetablePb_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                addVegetablePb.ImageLocation = openFileDialog.FileName;
                string[] imageName = openFileDialog.FileName.ToString().Split('\\');
                addVegetableImage = Guid.NewGuid().ToString() + "-" + imageName[imageName.Length - 1].ToString();

            }
            else
            {
                MessageBox.Show("Picture Selection Process Canceled.");
            }
        }
    }
}
