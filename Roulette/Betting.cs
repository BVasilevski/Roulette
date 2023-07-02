using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace Roulette
{
    public class Betting
    {
        public List<Square> numberSquares = new List<Square>(36);
        public Square blackSquare { get; set; }
        public Square redSquare { get; set; }
        public Square greenSquare { get; set; }

        public Point initialLocation { get; set; }

        public List<Bet> bets { get; set; } = new List<Bet>();
        public Betting(Point location, int width, int height, Size size)
        {
            initialLocation = location;
            int locX = size.Width + 500;
            int locY = initialLocation.Y + 70;

            int squaresPerRow = 3;
            int spacing = 10; // Adjust the spacing between squares if needed

            for (int i = 1; i <= 2; i++)
            {
                Square square;
                if (i % 2 == 0)
                    square = new Square(new Point(locX, locY), 1, i);
                else
                    square = new Square(new Point(locX, locY), 2, i);

                numberSquares.Add(square);

                locX += 35 + spacing;

                // Move to the next row after every squaresPerRow
                if (i % squaresPerRow == 0)
                {
                    locX = size.Width + 500;
                    locY += 30 + spacing;
                }
            }
/*
            Square middle = numberSquares[1];
            greenSquare = new Square(new Point(middle.Center.X + 40, initialLocation.Y + 25), 3, 0);
            greenSquare.Width = 45 * 2 + 35;

            Square square15 = numberSquares[14];

            blackSquare = new Square(new Point(square15.Center.X + 45, square15.Center.Y + 35), 2, -1);
            blackSquare.Height = 80;

            redSquare = new Square(new Point(blackSquare.Center.X, blackSquare.Center.Y + blackSquare.Height), 1, -1);
            redSquare.Height = 80;*/
        } 

        public void drawTable(Graphics g, Point location)
        {
            Brush b = new SolidBrush(Color.Black);
            //g.DrawRectangle(new Pen(Color.Black, 5), location.X + 900, location.Y + 10, 50, 50);
            foreach(Square square in numberSquares)
            {
                square.Draw(g);
            }
            //blackSquare.Draw(g);
            //redSquare.Draw(g);
            //greenSquare.Draw(g);
        }

        public void Click(Point location, int amount)
        {
            foreach(Square square in numberSquares)
            {
                if (square.isClicked(location))
                {
                    bets.Add(new Bet(square.Number, amount, square.Color));
                }
            }

           /* if (blackSquare.isClicked(location))
            {
                blackSquare.Clicked = true;
            }

            if (redSquare.isClicked(location))
            {
                redSquare.Clicked = true;
            }

            if (greenSquare.isClicked(location))
            {
                greenSquare.Clicked = true;
            }*/
        }
   
    }
}
