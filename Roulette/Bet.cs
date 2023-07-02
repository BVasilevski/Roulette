using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class Bet
    {
        public int Number { get; set; }
        public int Amount { get; set; }

        public Color Color { get; set; }

        public Bet(int number, int amount, Color color)
        {
            Number = number;
            Amount = amount;
            Color = color;
        }

        public override string? ToString()
        {
            return $"Number: {Number} - Amount: {Amount}";
        }
    }
}
