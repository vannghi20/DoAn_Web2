using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectWeb2.Models;

namespace ProjectWeb2.Interfaces
{
    public interface IProductLogic
    {
        Task<List<FoodItem>> GetAllFood();
        Task<List<FoodItem>> GetFoodNE();
        Task<List<FoodItem>> GetFoodGQ();
        Task<List<FoodItem>> GetFoodById(string id);
    }
}
