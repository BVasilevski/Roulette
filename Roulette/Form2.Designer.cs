namespace Roulette
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
            components = new System.ComponentModel.Container();
            depositBtn = new Button();
            label1 = new Label();
            nudAmount = new NumericUpDown();
            errorProvider1 = new ErrorProvider(components);
            cancelBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)nudAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // depositBtn
            // 
            depositBtn.Location = new Point(12, 81);
            depositBtn.Name = "depositBtn";
            depositBtn.Size = new Size(111, 23);
            depositBtn.TabIndex = 0;
            depositBtn.Text = "Deposit";
            depositBtn.UseVisualStyleBackColor = true;
            depositBtn.Click += depositBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 1;
            label1.Text = "Amount:";
            // 
            // nudAmount
            // 
            nudAmount.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            nudAmount.Location = new Point(72, 21);
            nudAmount.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            nudAmount.Name = "nudAmount";
            nudAmount.Size = new Size(170, 23);
            nudAmount.TabIndex = 2;
            nudAmount.Validating += nudAmount_Validating;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(129, 81);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(113, 23);
            cancelBtn.TabIndex = 3;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 119);
            Controls.Add(cancelBtn);
            Controls.Add(nudAmount);
            Controls.Add(label1);
            Controls.Add(depositBtn);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)nudAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button depositBtn;
        private Label label1;
        private NumericUpDown nudAmount;
        private ErrorProvider errorProvider1;
        private Button cancelBtn;
    }
}