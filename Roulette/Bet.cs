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

        public Bet(int number, int amount)
        {
            Number = number;
            Amount = amount;
        }

        public override string? ToString()
        {
            return $"Number: {Number} - Amount: {Amount}";
        }
    }
}
