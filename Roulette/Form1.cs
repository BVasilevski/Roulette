using System;
using System.Drawing;
using System.Windows.Forms;

namespace Roulette
{
    public partial class Form1 : Form
    {
        private Image wheelImage;
        private float rotationAngle = 0;
        private const float rotationSpeed = 5f;
        List<Button> buttons = new List<Button>();
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = Color.Green;
            wheelImage = Image.FromFile("D:\\desk\\resized.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabStop = false;
            pictureBox1.BackColor = Color.Green;
            pictureBox1.Size = wheelImage.Size;
            pictureBox1.Image = wheelImage;
            pictureBox1.Location = new Point((this.ClientSize.Width - pictureBox1.Width) / 2, (this.ClientSize.Height - pictureBox1.Height) / 2);
            //timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private Image RotateImage(Image image, float angle)
        {
            // Create a new bitmap with the same size as the original image
            Bitmap rotatedImage = new Bitmap(image.Width, image.Height);
            rotatedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                // Clear the background with a solid color
                g.Clear(Color.Green);

                // Set the interpolation mode to high quality
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                // Calculate the center point of the image
                float centerX = image.Width / 2f;
                float centerY = image.Height / 2f;

                // Translate, rotate, and draw the image
                g.TranslateTransform(centerX, centerY);
                g.RotateTransform(angle);
                g.TranslateTransform(-centerX, -centerY);
                g.DrawImage(image, new Point(0, 0));
            }

            return rotatedImage;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            rotationAngle += rotationSpeed;
            rotationAngle %= 360;
            pictureBox1.Image = RotateImage(wheelImage, rotationAngle);
            pictureBox1.Refresh(); // Forces immediate redraw of the PictureBox

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point((this.ClientSize.Width - pictureBox1.Width) / 2, (this.ClientSize.Height - pictureBox1.Height) / 2);

        }

        private void Form1_Resize_1(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point((this.ClientSize.Width - pictureBox1.Width) / 2, (this.ClientSize.Height - pictureBox1.Height) / 2);

        }
    }
}
