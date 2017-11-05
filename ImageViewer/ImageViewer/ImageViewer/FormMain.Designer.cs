namespace ImageViewer
{
    partial class FormMain
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_Tags = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.listBox_Tags = new System.Windows.Forms.ListBox();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.buttonGetListFromDB = new System.Windows.Forms.Button();
            this.buttonLoadFromDB = new System.Windows.Forms.Button();
            this.buttonSaveToDB = new System.Windows.Forms.Button();
            this.listBox_ImageTitle = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 25);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open From File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonOpenFromFile_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(111, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = "Save To File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonSaveToFile_Click);
            // 
            // textBox_Tags
            // 
            this.textBox_Tags.Location = new System.Drawing.Point(3, 38);
            this.textBox_Tags.Name = "textBox_Tags";
            this.textBox_Tags.Size = new System.Drawing.Size(212, 20);
            this.textBox_Tags.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 64);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Add Tag";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonAddTag_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(111, 64);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Remove Tag";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonRemoveTag_Click);
            // 
            // listBox_Tags
            // 
            this.listBox_Tags.FormattingEnabled = true;
            this.listBox_Tags.Location = new System.Drawing.Point(221, 7);
            this.listBox_Tags.Name = "listBox_Tags";
            this.listBox_Tags.Size = new System.Drawing.Size(123, 82);
            this.listBox_Tags.TabIndex = 5;
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Location = new System.Drawing.Point(6, 93);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(687, 400);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxMain.TabIndex = 6;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.Click += new System.EventHandler(this.pictureBoxMain_Click);
            // 
            // buttonGetListFromDB
            // 
            this.buttonGetListFromDB.Location = new System.Drawing.Point(364, 7);
            this.buttonGetListFromDB.Name = "buttonGetListFromDB";
            this.buttonGetListFromDB.Size = new System.Drawing.Size(104, 23);
            this.buttonGetListFromDB.TabIndex = 7;
            this.buttonGetListFromDB.Text = "Get List From DB";
            this.buttonGetListFromDB.UseVisualStyleBackColor = true;
            // 
            // buttonLoadFromDB
            // 
            this.buttonLoadFromDB.Location = new System.Drawing.Point(364, 36);
            this.buttonLoadFromDB.Name = "buttonLoadFromDB";
            this.buttonLoadFromDB.Size = new System.Drawing.Size(104, 23);
            this.buttonLoadFromDB.TabIndex = 8;
            this.buttonLoadFromDB.Text = "LoadFromDB";
            this.buttonLoadFromDB.UseVisualStyleBackColor = true;
            // 
            // buttonSaveToDB
            // 
            this.buttonSaveToDB.Location = new System.Drawing.Point(364, 64);
            this.buttonSaveToDB.Name = "buttonSaveToDB";
            this.buttonSaveToDB.Size = new System.Drawing.Size(104, 23);
            this.buttonSaveToDB.TabIndex = 9;
            this.buttonSaveToDB.Text = "Save To DB";
            this.buttonSaveToDB.UseVisualStyleBackColor = true;
            // 
            // listBox_ImageTitle
            // 
            this.listBox_ImageTitle.FormattingEnabled = true;
            this.listBox_ImageTitle.Location = new System.Drawing.Point(474, 7);
            this.listBox_ImageTitle.Name = "listBox_ImageTitle";
            this.listBox_ImageTitle.Size = new System.Drawing.Size(219, 82);
            this.listBox_ImageTitle.TabIndex = 10;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 499);
            this.Controls.Add(this.listBox_ImageTitle);
            this.Controls.Add(this.buttonSaveToDB);
            this.Controls.Add(this.buttonLoadFromDB);
            this.Controls.Add(this.buttonGetListFromDB);
            this.Controls.Add(this.pictureBoxMain);
            this.Controls.Add(this.listBox_Tags);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox_Tags);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Image Viewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_Tags;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox listBox_Tags;
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Button buttonGetListFromDB;
        private System.Windows.Forms.Button buttonLoadFromDB;
        private System.Windows.Forms.Button buttonSaveToDB;
        private System.Windows.Forms.ListBox listBox_ImageTitle;
    }
}

