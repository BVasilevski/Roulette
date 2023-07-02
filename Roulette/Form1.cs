namespace Roulette
{
    public partial class Form1 : Form
    {
        private Image wheelImage;
        private float rotationAngle = 0;
        private const float rotationSpeed = 2f;
        private Ball ball;
        private Betting table;
        private int ticks = 0;
        private Random random = new Random();
        List<int> tickValues = new List<int>();
        int drawnNumber;
        int duration;
        Dictionary<int, int> numbers = new Dictionary<int, int>()
        {
            { 598, 28 },
            { 593, 7 },
            { 588, 29 },
            { 583, 18 },
            { 578, 22 },
            { 573, 9 },
            { 569, 31 },
            { 564, 14 },
            { 559, 20 },
            { 554, 1 },
            { 549, 33 },
            { 544, 15 },
            { 540, 24 },
            { 535, 5 },
            { 530, 10 },
            { 525, 23 },
            { 520, 8 },
            { 515, 30 },
            { 510, 11 },
            { 506, 36 },
            { 501, 13 },
            { 496, 34 },
            { 491, 6 },
            { 486, 27 },
            { 481, 17 },
            { 476, 25 },
            { 471, 2 },
            { 467, 21 },
            { 462, 4 },
            { 457, 19 },
            { 452, 15 },
            { 447, 32 },
            { 442, 0 },
            { 437, 26 },
            { 433, 3 },
            { 428, 35 },
            { 423, 12 }
        };

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = Color.Green;

            wheelImage = Image.FromFile("wheel.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabStop = false;
            pictureBox1.BackColor = Color.Green;
            pictureBox1.Size = wheelImage.Size;
            pictureBox1.Image = wheelImage;
            pictureBox1.Location = new Point((30), (this.ClientSize.Height - pictureBox1.Height) / 2);

            currentBetsList.BackColor = Color.Green;
            spinButton.Location = new Point(this.Width / 2, spinButton.Location.Y);

            table = new Betting(pictureBox1.Location, this.Width, this.Height, pictureBox1.Size);
            ball = new Ball(new Point(200, 65));
            tickValues = new List<int>(numbers.Keys.ToArray());
        }

        private Image RotateImage(Image image, float angle)
        {
            // Create a new bitmap with the same size as the original image
            Bitmap rotatedImage = new Bitmap(image.Width, image.Height);
            rotatedImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                // Clear the background with a solid color
                g.Clear(Color.Transparent);

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
            ball.UpdatePosition();
        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point((30), (this.ClientSize.Height - pictureBox1.Height) / 2);
            Invalidate();
        }

        private void Form1_Resize_1(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point((30), (this.ClientSize.Height - pictureBox1.Height) / 2);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            table.drawTable(e.Graphics, pictureBox1.Location);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ball = new Ball(new Point(200, 65));
            timerBall.Start();
            showCurrentBets();
            duration = tickValues[random.Next(tickValues.Count)];
            ticks = 0;
            pictureBox1.Invalidate();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            ball.Draw(e.Graphics);
        }

        private void timerBall_Tick(object sender, EventArgs e)
        {
            ticks++;
            ball.UpdatePosition();

            if (ticks > 200)
            {
                ball.RotationSpeed = 2f;
            }

            if (ticks == duration)
            {
                timerBall.Stop();
                drawnNumber = numbers[duration];
                table.bets.Clear();    
            }

            //label1.Text = drawnNumber.ToString();
            //label2.Text = $"Duration - {duration.ToString()}";
            //label3.Text = $"Ticks - {ticks.ToString()}";
            pictureBox1.Invalidate();
        }

        private void currentBetsList_MouseClick(object sender, MouseEventArgs e)
        {

        }

        public void showCurrentBets()
        {
            currentBetsList.Items.Clear();
            if (table.bets.Count > 0)
            {
                foreach (Bet bet in table.bets)
                {
                    currentBetsList.Items.Add(bet);
                }
            }  
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            table.Click(e.Location, 50);
            //Invalidate();
        }
    }
}
