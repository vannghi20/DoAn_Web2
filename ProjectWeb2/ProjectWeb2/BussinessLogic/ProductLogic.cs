using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectWeb2.Common.Constants;
using ProjectWeb2.Interfaces;
using ProjectWeb2.Models;

namespace ProjectWeb2.BussinessLogic
{
    public class ProductLogic : IProductLogic
    {
        Constants c = new Constants();
        private IApiService _apiService;
        public ProductLogic(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<FoodItem>> GetAllFood()
        {
            var response = await _apiService.GetApi(Constants.GetFoodItemPath);
            var model = JsonConvert.DeserializeObject<List<FoodItem>>(response);

            return model;
        }

        public async Task<List<FoodItem>> GetFoodById(string id)
        {
            var response = await _apiService.GetApi(c.GetFoodByIdPath(id));
            var model = JsonConvert.DeserializeObject<List<FoodItem>>(response);
            return model;
        }

        public async Task<List<FoodItem>> GetFoodGQ()
        {
            var response = await _apiService.GetApi(Constants.GetFoodGQPath);
            var model = JsonConvert.DeserializeObject<List<FoodItem>>(response);
            return model;
        }
        public async Task<List<FoodItem>> GetFoodNE()
        {
            var response = await _apiService.GetApi(Constants.GetFoodNEPath);
            var model = JsonConvert.DeserializeObject<List<FoodItem>>(response);
            return model;
        }
    }
}
