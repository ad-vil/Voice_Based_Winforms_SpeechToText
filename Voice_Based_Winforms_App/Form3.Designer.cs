namespace Voice_Based_Winforms_App
{
    partial class Form3
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
            backBtn = new Button();
            titleLbl = new Label();
            kneePainLbl = new Label();
            elbowPainLbl = new Label();
            shoulderPainLbl = new Label();
            kneePainSlider = new TrackBar();
            elbowPainSlider = new TrackBar();
            shoulderPainSlider = new TrackBar();
            firstNameLbl = new Label();
            lastNameLbl = new Label();
            cityLbl = new Label();
            countryLbl = new Label();
            btnNextForm = new Button();
            ((System.ComponentModel.ISupportInitialize)kneePainSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)elbowPainSlider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)shoulderPainSlider).BeginInit();
            SuspendLayout();
            // 
            // backBtn
            // 
            backBtn.Location = new Point(12, 12);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(94, 29);
            backBtn.TabIndex = 0;
            backBtn.Text = "Back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // titleLbl
            // 
            titleLbl.AutoSize = true;
            titleLbl.Font = new Font("Segoe UI", 18F);
            titleLbl.Location = new Point(309, 27);
            titleLbl.Name = "titleLbl";
            titleLbl.Size = new Size(169, 41);
            titleLbl.TabIndex = 1;
            titleLbl.Text = "Patient Info";
            // 
            // kneePainLbl
            // 
            kneePainLbl.AutoSize = true;
            kneePainLbl.Font = new Font("Segoe UI", 12F);
            kneePainLbl.Location = new Point(528, 106);
            kneePainLbl.Name = "kneePainLbl";
            kneePainLbl.Size = new Size(96, 28);
            kneePainLbl.TabIndex = 2;
            kneePainLbl.Text = "Knee Pain";
            // 
            // elbowPainLbl
            // 
            elbowPainLbl.AutoSize = true;
            elbowPainLbl.Font = new Font("Segoe UI", 12F);
            elbowPainLbl.Location = new Point(527, 200);
            elbowPainLbl.Name = "elbowPainLbl";
            elbowPainLbl.Size = new Size(106, 28);
            elbowPainLbl.TabIndex = 2;
            elbowPainLbl.Text = "Elbow Pain";
            // 
            // shoulderPainLbl
            // 
            shoulderPainLbl.AutoSize = true;
            shoulderPainLbl.Font = new Font("Segoe UI", 12F);
            shoulderPainLbl.Location = new Point(518, 307);
            shoulderPainLbl.Name = "shoulderPainLbl";
            shoulderPainLbl.Size = new Size(132, 28);
            shoulderPainLbl.TabIndex = 2;
            shoulderPainLbl.Text = "Shoulder Pain";
            // 
            // kneePainSlider
            // 
            kneePainSlider.Location = new Point(459, 137);
            kneePainSlider.Name = "kneePainSlider";
            kneePainSlider.Size = new Size(238, 56);
            kneePainSlider.TabIndex = 3;
            // 
            // elbowPainSlider
            // 
            elbowPainSlider.Location = new Point(459, 231);
            elbowPainSlider.Name = "elbowPainSlider";
            elbowPainSlider.Size = new Size(238, 56);
            elbowPainSlider.TabIndex = 3;
            // 
            // shoulderPainSlider
            // 
            shoulderPainSlider.Location = new Point(459, 338);
            shoulderPainSlider.Name = "shoulderPainSlider";
            shoulderPainSlider.Size = new Size(238, 56);
            shoulderPainSlider.TabIndex = 3;
            // 
            // firstNameLbl
            // 
            firstNameLbl.AutoSize = true;
            firstNameLbl.Location = new Point(80, 137);
            firstNameLbl.Name = "firstNameLbl";
            firstNameLbl.Size = new Size(94, 20);
            firstNameLbl.TabIndex = 4;
            firstNameLbl.Text = "firstNameLbl";
            // 
            // lastNameLbl
            // 
            lastNameLbl.AutoSize = true;
            lastNameLbl.Location = new Point(80, 204);
            lastNameLbl.Name = "lastNameLbl";
            lastNameLbl.Size = new Size(92, 20);
            lastNameLbl.TabIndex = 4;
            lastNameLbl.Text = "lastNameLbl";
            // 
            // cityLbl
            // 
            cityLbl.AutoSize = true;
            cityLbl.Location = new Point(80, 271);
            cityLbl.Name = "cityLbl";
            cityLbl.Size = new Size(52, 20);
            cityLbl.TabIndex = 4;
            cityLbl.Text = "cityLbl";
            // 
            // countryLbl
            // 
            countryLbl.AutoSize = true;
            countryLbl.Location = new Point(80, 338);
            countryLbl.Name = "countryLbl";
            countryLbl.Size = new Size(78, 20);
            countryLbl.TabIndex = 4;
            countryLbl.Text = "countryLbl";
            // 
            // btnNextForm
            // 
            btnNextForm.Location = new Point(694, 12);
            btnNextForm.Name = "btnNextForm";
            btnNextForm.Size = new Size(94, 29);
            btnNextForm.TabIndex = 5;
            btnNextForm.Text = "To Form 4";
            btnNextForm.UseVisualStyleBackColor = true;
            btnNextForm.Click += btnNextForm_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNextForm);
            Controls.Add(countryLbl);
            Controls.Add(cityLbl);
            Controls.Add(lastNameLbl);
            Controls.Add(firstNameLbl);
            Controls.Add(shoulderPainSlider);
            Controls.Add(elbowPainSlider);
            Controls.Add(kneePainSlider);
            Controls.Add(shoulderPainLbl);
            Controls.Add(elbowPainLbl);
            Controls.Add(kneePainLbl);
            Controls.Add(titleLbl);
            Controls.Add(backBtn);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)kneePainSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)elbowPainSlider).EndInit();
            ((System.ComponentModel.ISupportInitialize)shoulderPainSlider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backBtn;
        private Label titleLbl;
        private Label kneePainLbl;
        private Label elbowPainLbl;
        private Label shoulderPainLbl;
        private TrackBar kneePainSlider;
        private TrackBar elbowPainSlider;
        private TrackBar shoulderPainSlider;
        private Label firstNameLbl;
        private Label lastNameLbl;
        private Label cityLbl;
        private Label countryLbl;
        private Button btnNextForm;
    }
}