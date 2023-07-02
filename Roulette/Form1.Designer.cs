namespace Roulette
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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            spinButton = new Button();
            timerBall = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            currentBetsList = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(324, 410);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 80);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // timer1
            // 
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick_1;
            // 
            // spinButton
            // 
            spinButton.Location = new Point(426, 519);
            spinButton.Name = "spinButton";
            spinButton.Size = new Size(75, 23);
            spinButton.TabIndex = 1;
            spinButton.Text = "SPIN";
            spinButton.UseVisualStyleBackColor = true;
            spinButton.Click += button1_Click;
            // 
            // timerBall
            // 
            timerBall.Interval = 10;
            timerBall.Tick += timerBall_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(711, 4);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 2;
            label1.Text = "Current Bets:";
            // 
            // currentBetsList
            // 
            currentBetsList.FormattingEnabled = true;
            currentBetsList.ItemHeight = 15;
            currentBetsList.Location = new Point(563, 22);
            currentBetsList.Name = "currentBetsList";
            currentBetsList.Size = new Size(362, 484);
            currentBetsList.TabIndex = 5;
            currentBetsList.MouseClick += currentBetsList_MouseClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1141, 554);
            Controls.Add(currentBetsList);
            Controls.Add(label1);
            Controls.Add(spinButton);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            ResizeEnd += Form1_ResizeEnd;
            Paint += Form1_Paint;
            MouseClick += Form1_MouseClick;
            Resize += Form1_Resize_1;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private Button spinButton;
        private System.Windows.Forms.Timer timerBall;
        private Label label1;
        private ListBox currentBetsList;
    }
}