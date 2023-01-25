namespace GroccerManagment
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fruitBtn = new System.Windows.Forms.Button();
            this.vegetableBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fruitBtn
            // 
            this.fruitBtn.Location = new System.Drawing.Point(180, 271);
            this.fruitBtn.Name = "fruitBtn";
            this.fruitBtn.Size = new System.Drawing.Size(130, 60);
            this.fruitBtn.TabIndex = 0;
            this.fruitBtn.Text = "FRUİT";
            this.fruitBtn.UseVisualStyleBackColor = true;
            this.fruitBtn.Click += new System.EventHandler(this.fruitBtn_Click);
            // 
            // vegetableBtn
            // 
            this.vegetableBtn.Location = new System.Drawing.Point(180, 370);
            this.vegetableBtn.Name = "vegetableBtn";
            this.vegetableBtn.Size = new System.Drawing.Size(130, 60);
            this.vegetableBtn.TabIndex = 1;
            this.vegetableBtn.Text = "VEGETABLE";
            this.vegetableBtn.UseVisualStyleBackColor = true;
            this.vegetableBtn.Click += new System.EventHandler(this.vegetableBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GroccerManagment.Properties.Resources.a4e0bf093c8;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.vegetableBtn);
            this.Controls.Add(this.fruitBtn);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button fruitBtn;
        private System.Windows.Forms.Button vegetableBtn;
    }
}

