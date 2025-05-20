namespace Voice_Based_Winforms_App
{
    partial class Form4
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
            btnStartTraining = new Button();
            btnStopTraining = new Button();
            txtTraining = new TextBox();
            btnBack = new Button();
            SuspendLayout();
            // 
            // btnStartTraining
            // 
            btnStartTraining.Location = new Point(310, 83);
            btnStartTraining.Name = "btnStartTraining";
            btnStartTraining.Size = new Size(152, 29);
            btnStartTraining.TabIndex = 0;
            btnStartTraining.Text = "Start Training";
            btnStartTraining.UseVisualStyleBackColor = true;
            btnStartTraining.Click += btnStartTraining_Click;
            // 
            // btnStopTraining
            // 
            btnStopTraining.Location = new Point(310, 338);
            btnStopTraining.Name = "btnStopTraining";
            btnStopTraining.Size = new Size(152, 29);
            btnStopTraining.TabIndex = 1;
            btnStopTraining.Text = "Stop Training";
            btnStopTraining.UseVisualStyleBackColor = true;
            // 
            // txtTraining
            // 
            txtTraining.Location = new Point(181, 141);
            txtTraining.Multiline = true;
            txtTraining.Name = "txtTraining";
            txtTraining.Size = new Size(439, 164);
            txtTraining.TabIndex = 2;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(127, 28);
            btnBack.TabIndex = 3;
            btnBack.Text = "Back to Form 1";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(txtTraining);
            Controls.Add(btnStopTraining);
            Controls.Add(btnStartTraining);
            Name = "Form4";
            Text = "Form4";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartTraining;
        private Button btnStopTraining;
        private TextBox txtTraining;
        private Button btnBack;
    }
}