using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb2.Models
{
    public class CartItem
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantyti { get; set; }
        public double Price { get; set; }
        public string ProductTile { get; set; }
        public double Total() { return this.Price * this.Quantyti; }
    }
}
