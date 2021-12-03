using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb2.Models
{
    public class FoodItem
    {
        public List<FoodItem> foodItems;
        public int Id { get; set; }
        public string ImgSource { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        public int Price { get; set; }
    }
}
