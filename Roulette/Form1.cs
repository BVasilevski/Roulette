using System.Diagnostics.Eventing.Reader;
using System.Media;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.InteropServices;
using System.ComponentModel;

// ...



namespace Roulette
{

    public partial class Form1 : Form
    {

        //TODO: STAVI ZA BRISENJE NA BETOVITE
        private Image wheelImage;
        private float rotationAngle = 0;
        private const float rotationSpeed = 2f;
        private Ball ball;
        private Betting Betting;
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
        List<Button> buttons = new List<Button>();
        private Wallet wallet = new Wallet(0);
        private SoundPlayer player;

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
            pictureBox1.Location = new Point((30), (this.ClientSize.Height - pictureBox1.Height) - 20);

            currentBetsList.BackColor = Color.Green;
            //GenerateButtons();
            Betting = new Betting();
            ball = new Ball(new Point(200, 65));
            tickValues = new List<int>(numbers.Keys.ToArray());
            tbCurrentBalance.Text = wallet.ToString();
            player = new SoundPlayer("clap.wav");

        }

        private Button GetButtonByText(string buttonText)
        {
            foreach (Control control in Controls)
            {
                if (control is Button button && button.Text == buttonText)
                {
                    return button;
                }
            }

            return null; // Button with the specified text not found
        }
        public void GenerateButtons()
        {
            int x = pictureBox1.Width + 450;
            int y = pictureBox1.Location.Y - 20;
            int ButtonSize = 40;
            const int ButtonSpacing = 0;

            // Add the green button above buttons 1, 2, and 3
            Button greenButton = new Button();
            greenButton.Width = ButtonSize * 3 + ButtonSpacing * 2;
            greenButton.Height = ButtonSize;
            greenButton.Location = new Point(x, y);
            greenButton.ForeColor = Color.White;
            greenButton.Font = new Font(greenButton.Font.FontFamily, 12f, greenButton.Font.Style);
            greenButton.Text = "0";
            greenButton.BackColor = Color.Green;
            Controls.Add(greenButton);
            buttons.Add(greenButton);
            y += ButtonSize + ButtonSpacing;

            for (int i = 1; i <= 36; i++)
            {
                Button button = new Button();
                button.Width = button.Height = ButtonSize;
                button.Location = new Point(x, y);
                button.ForeColor = Color.White;
                button.Font = new Font(button.Font.FontFamily, 12f, button.Font.Style);
                button.Text = i.ToString();

                button.BackColor = i % 2 == 0 ? Color.Red : Color.Black;


                Controls.Add(button);
                buttons.Add(button);

                x += ButtonSize + ButtonSpacing;
                if (i % 3 == 0)
                {
                    x = pictureBox1.Width + 450;
                    y += ButtonSize + ButtonSpacing;
                }
            }
            Button button12 = GetButtonByText(15.ToString());

            Button redButton = new Button();
            redButton.Location = new Point(button12.Location.X + ButtonSize, button12.Location.Y);
            redButton.Width = 40;
            redButton.Height = 2 * button12.Height;
            redButton.BackColor = Color.Red;
            Controls.Add(redButton);

            Button button21 = GetButtonByText(21.ToString());
            Button blackButton = new Button();
            blackButton.Location = new Point(button21.Location.X + ButtonSize, button21.Location.Y);
            blackButton.Width = 40;
            blackButton.Height = 2 * button12.Height;
            blackButton.BackColor = Color.Black;
            Controls.Add(blackButton);
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
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //table.drawTable(e.Graphics, pictureBox1.Location);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ball = new Ball(new Point(200, 65));
            if (Betting.bets.Count > 0)
            {
                timerBall.Start();
                duration = tickValues[random.Next(tickValues.Count)];
                amountNud.Value = 0;
                ticks = 0;
            }
            else
            {
                MessageBox.Show("Please add some bets", "Add bets", MessageBoxButtons.OK);
            }
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
            pictureBox1.Invalidate();
            if (ticks > 200)
            {
                ball.RotationSpeed = 2f;
            }

            if (ticks == duration)
            {
                timerBall.Stop();
                drawnNumber = numbers[duration];
                int amount = Betting.CalculateWinning(drawnNumber);
                if (amount > 0)
                {
                    player.Play();
                    DialogResult dg = MessageBox.Show("Congratulations! You won: " + amount.ToString(), "Congratulations!", MessageBoxButtons.OK);
                    if (dg == DialogResult.OK)
                    {
                        player.Stop();
                    }
                    wallet.addValue(amount);
                    updateCurrentBalance();
                }
                Betting.bets.Clear();
                showCurrentBets();
            }

        }



        public void showCurrentBets()
        {
            int i = 1;
            currentBetsList.Items.Clear();
            if (Betting.bets.Count > 0)
            {
                foreach (Bet bet in Betting.bets)
                {
                    currentBetsList.Items.Add($"{i}. " + bet);
                    i++;
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int number = int.Parse(button.Text);
            int containedBetAmount = 0;
            bool contains = false;
            int amount = int.Parse(amountNud.Text);
            if (int.Parse(tbCurrentBalance.Text) >= amount)
            {
                if (amount > 0)
                {
                    for (int i = Betting.bets.Count - 1; i >= 0; i--)
                    {
                        if (Betting.bets[i].Number == number)
                        {
                            containedBetAmount = Betting.bets[i].Amount;
                            Betting.bets.Remove(Betting.bets[i]);
                            contains = true;
                        }
                    }

                    if (contains)
                    {
                        Betting.bets.Add(new Bet(number, (amount + containedBetAmount)));
                    }

                    else
                    {
                        Betting.bets.Add(new Bet(number, amount));
                    }
                    wallet.removeValue(amount);
                }
                else
                {
                    DialogResult dg = MessageBox.Show("Please put amount for the bet", "Please put amount for the bet", MessageBoxButtons.OK);
                }
            }
            else
            {
                DialogResult dg = MessageBox.Show("You dont have enough balance", "You dont have enough balance", MessageBoxButtons.OK);
            }

            updateCurrentBalance();
            showCurrentBets();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int number = int.Parse(button.Text);
            int amount = int.Parse(amountNud.Text);

            if (int.Parse(tbCurrentBalance.Text) >= amount)
            {
                if (amount > 0)
                {
                    Betting.bets.Add(new Bet(number, amount));
                    wallet.removeValue(amount);
                }
                else
                {
                    DialogResult dg = MessageBox.Show("Please put amount for the bet", "Please put amount for the bet", MessageBoxButtons.OK);
                }
            }

            else
            {
                DialogResult dg = MessageBox.Show("You dont have enough balance", "You dont have enough balance", MessageBoxButtons.OK);
            }

            updateCurrentBalance();
            showCurrentBets();
        }


        private void buttonRed_Click(object sender, EventArgs e)
        {
            bool contains = false;
            int amount = int.Parse(amountNud.Text);
            int containedBetAmount = 0;
            if (int.Parse(tbCurrentBalance.Text) >= amount)
            {
                if (amount > 0)
                {
                    for (int i = Betting.bets.Count - 1; i >= 0; i--)
                    {
                        if (Betting.bets[i].Number == -1)
                        {
                            containedBetAmount = Betting.bets[i].Amount;
                            Betting.bets.Remove(Betting.bets[i]);
                            contains = true;
                        }
                    }

                    if (contains)
                    {
                        Betting.bets.Add(new Bet(-1, (amount + containedBetAmount)));
                    }

                    else
                    {
                        Betting.bets.Add(new Bet(-1, amount));
                    }
                    wallet.removeValue(amount);
                }
                else
                {
                    DialogResult dg = MessageBox.Show("Please put amount for the bet", "Please put amount for the bet", MessageBoxButtons.OK);
                }
            }

            updateCurrentBalance();
            showCurrentBets();
        }

        private void updateCurrentBalance()
        {
            tbCurrentBalance.Text = wallet.ToString();
        }

        private void buttonBlack_Click(object sender, EventArgs e)
        {
            bool contains = false;
            int amount = int.Parse(amountNud.Text);
            int containedBetAmount = 0;
            if (int.Parse(tbCurrentBalance.Text) >= amount)
            {
                if (amount > 0)
                {
                    for (int i = Betting.bets.Count - 1; i >= 0; i--)
                    {
                        if (Betting.bets[i].Number == -2)
                        {
                            containedBetAmount = Betting.bets[i].Amount;
                            Betting.bets.Remove(Betting.bets[i]);
                            contains = true;
                        }
                    }

                    if (contains)
                    {
                        Betting.bets.Add(new Bet(-2, (amount + containedBetAmount)));
                    }

                    else
                    {
                        Betting.bets.Add(new Bet(-2, amount));
                    }
                    wallet.removeValue(amount);
                }
                else
                {
                    DialogResult dg = MessageBox.Show("Please put amount for the bet", "Please put amount for the bet", MessageBoxButtons.OK);
                }
            }
            else
            {
                DialogResult dg = MessageBox.Show("You dont have enough balance", "You dont have enough balance", MessageBoxButtons.OK);
            }

            updateCurrentBalance();
            showCurrentBets();
        }

        private void btnDepositMoney_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            if (form.ShowDialog() == DialogResult.OK)
            {
                wallet.addValue(form.amount);
                updateCurrentBalance();
            }
        }

        private void btnRemoveLastBet_Click(object sender, EventArgs e)
        {
            if (Betting.bets.Count > 0)
            {
                Betting.RemoveLastBet(wallet);
            }
            showCurrentBets();
            updateCurrentBalance();
        }

        private void btnRemoveAllBets_Click(object sender, EventArgs e)
        {
            Betting.RemoveAllBets(wallet);
            showCurrentBets();
            updateCurrentBalance();
        }

        private void btnRules_Click(object sender, EventArgs e)
        {
            RulesForm form = new RulesForm();
            form.ShowDialog();
        }
    }
}
