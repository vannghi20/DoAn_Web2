using ProjectWeb2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb2.Common.Constants
{
    public class Constants
    {
        public static readonly string GetFoodItemPath = "/api/fooditem";
        public static readonly string GetFoodBslPath = "/api/FoodItem/bsl";
        public static readonly string GetFoodNEPath = "/api/FoodItem/ne";
        public static readonly string GetFoodGQPath = "/api/FoodItem/gq";
        public string GetFoodByIdPath(string id)
        {
            var path = $"api/FoodItem/{id}";
            return path;
        }
        public string UpdateFoodPath()
        {
            FoodItem f = new FoodItem();
            var path = $"api/FoodItem/{f.Id}";
            return path;
        }
        public static readonly string AddFoodPath = "/api/FoodItem/add";
        public string DeleteFoodPath()
        {
            FoodItem f = new FoodItem();
            var path = $"api/FoodItem/{f.Id}";
            return path;
        }
    }
}
