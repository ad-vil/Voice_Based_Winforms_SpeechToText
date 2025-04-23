namespace Voice_Based_Winforms_App
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStart = new Button();
            txtOutput = new TextBox();
            btnStop = new Button();
            Title = new Label();
            form2btn = new Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(327, 121);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(146, 54);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start transcription";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // txtOutput
            // 
            txtOutput.Location = new Point(160, 195);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.Size = new Size(481, 134);
            txtOutput.TabIndex = 1;
            txtOutput.TextChanged += textBox1_TextChanged;
            // 
            // btnStop
            //  
            btnStop.Location = new Point(353, 375);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(94, 29);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += button1_Click;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Segoe UI", 18F);
            Title.Location = new Point(215, 23);
            Title.Name = "Title";
            Title.Size = new Size(370, 41);
            Title.TabIndex = 3;
            Title.Text = "Speech to Text Application";
            // 
            // form2btn
            // 
            form2btn.Location = new Point(666, 12);
            form2btn.Name = "form2btn";
            form2btn.Size = new Size(122, 52);
            form2btn.TabIndex = 4;
            form2btn.Text = "Go to form 2";
            form2btn.UseVisualStyleBackColor = true;
            form2btn.Click += form2btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(form2btn);
            Controls.Add(Title);
            Controls.Add(btnStop);
            Controls.Add(txtOutput);
            Controls.Add(btnStart);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private TextBox txtOutput;
        private Button btnStop;
        private Label Title;
        private Button form2btn;
    }
}
