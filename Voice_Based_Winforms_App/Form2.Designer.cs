namespace Voice_Based_Winforms_App
{
    partial class Form2
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
            Title = new Label();
            btnCloseForm = new Button();
            fNameBox = new TextBox();
            lNameBox = new TextBox();
            cityBox = new TextBox();
            countryBox = new TextBox();
            addBtn = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnLoad = new Button();
            btnSave = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Segoe UI", 18F);
            Title.Location = new Point(336, 12);
            Title.Name = "Title";
            Title.Size = new Size(111, 41);
            Title.TabIndex = 0;
            Title.Text = "Form 2";
            Title.Click += Title_Click;
            // 
            // btnCloseForm
            // 
            btnCloseForm.Location = new Point(12, 12);
            btnCloseForm.Name = "btnCloseForm";
            btnCloseForm.Size = new Size(121, 36);
            btnCloseForm.TabIndex = 1;
            btnCloseForm.Text = "Back to Form 1";
            btnCloseForm.UseVisualStyleBackColor = true;
            btnCloseForm.Click += btnCloseForm_Click;
            // 
            // fNameBox
            // 
            fNameBox.Location = new Point(57, 94);
            fNameBox.Name = "fNameBox";
            fNameBox.PlaceholderText = "First name...";
            fNameBox.Size = new Size(189, 27);
            fNameBox.TabIndex = 2;
            fNameBox.TextChanged += fName_TextChanged;
            // 
            // lNameBox
            // 
            lNameBox.Location = new Point(57, 155);
            lNameBox.Name = "lNameBox";
            lNameBox.PlaceholderText = "Last name...";
            lNameBox.Size = new Size(189, 27);
            lNameBox.TabIndex = 3;
            lNameBox.TextChanged += lNameBox_TextChanged;
            // 
            // cityBox
            // 
            cityBox.Location = new Point(57, 219);
            cityBox.Name = "cityBox";
            cityBox.PlaceholderText = "City...";
            cityBox.Size = new Size(189, 27);
            cityBox.TabIndex = 4;
            cityBox.TextChanged += cityBox_TextChanged;
            // 
            // countryBox
            // 
            countryBox.Location = new Point(57, 277);
            countryBox.Name = "countryBox";
            countryBox.PlaceholderText = "Country...";
            countryBox.Size = new Size(189, 27);
            countryBox.TabIndex = 5;
            countryBox.TextChanged += countryBox_TextChanged;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(353, 367);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(94, 29);
            addBtn.TabIndex = 6;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(57, 367);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(205, 367);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(501, 367);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 9;
            btnLoad.Text = "Load CSV";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(649, 367);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save CSV";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(336, 94);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(407, 210);
            dataGridView1.TabIndex = 11;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(btnSave);
            Controls.Add(btnLoad);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(addBtn);
            Controls.Add(countryBox);
            Controls.Add(cityBox);
            Controls.Add(lNameBox);
            Controls.Add(fNameBox);
            Controls.Add(btnCloseForm);
            Controls.Add(Title);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Title;
        private Button btnCloseForm;
        private TextBox fNameBox;
        private TextBox lNameBox;
        private TextBox cityBox;
        private TextBox countryBox;
        private Button addBtn;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnLoad;
        private Button btnSave;
        private DataGridView dataGridView1;
    }
}