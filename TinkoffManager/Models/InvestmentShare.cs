using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinkoffManager.Models
{
    public class InvestmentShare
    {
        public string Name { get; set; }
        public int Lots { get; set; }
        public int Balance { get; set; }
        public float Price { get; set; }
        public string Currency { get; set; }

        public InvestmentShare() { }

        public InvestmentShare(string name, int lots, int balance, float price, string currency)
        {
            this.Name = name;
            this.Lots = lots;
            this.Balance = balance;
            this.Price = price;
            this.Currency = currency;
        }


    }
}
