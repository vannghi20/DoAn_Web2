using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ProjectWeb2.Interfaces;
using ProjectWeb2.Models;

namespace ProjectWeb2.BussinessLogic
{
    public class CartItemLogic : ICartItemLogic
    {
        private readonly ISqlHelper _sqlHelper;

        public CartItemLogic(ISqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }
        public async Task<bool> CreateNewCart(CartItem cart)
        {
            string query = "insert into CartItem (ProductId,Quantyti,Price,ProductTile) values (@ProductId,@Quantyti,@Price,@ProductTile);";
            var parameters = new IDataParameter[]
            {
                new SqlParameter("@ProductId", cart.ProductId),
                new SqlParameter("@Quantyti",cart.Quantyti),
                new SqlParameter("@Price",cart.Price),
                new SqlParameter("@ProductTile",cart.ProductTile),
           };

            if (await _sqlHelper.ExcuteDate(query, parameters) > 0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        public async Task<List<CartItem>> GetAllCart()
        {
            DataTable dt = await _sqlHelper.GetData("select * from CartItem");
            List<CartItem> cartList = new List<CartItem>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CartItem cart = new CartItem();
                cart.CartId = (int)dt.Rows[i]["Id"];
                cart.ProductId = (int)dt.Rows[i]["ProductId"];
                cart.Quantyti = (int)dt.Rows[i]["Quantyti"];
                cart.Price = (double)dt.Rows[i]["Price"];
                cart.ProductTile = dt.Rows[i]["ProductTile"].ToString();

                if (cartList.Select(c => c.ProductId).Contains(cart.ProductId))
                {
                    var existCard = cartList.FirstOrDefault(c => c.ProductId == cart.ProductId);
                    existCard.Quantyti += cart.Quantyti;
                }
                else
                {
                    cartList.Add(cart);
                }
            }
            return cartList;
        }
        public async Task<bool> RemoveCart(int id)
        {
            string query = "delete from CartItem where ProductId = @Id;";
            var parameters = new IDataParameter[]
            {
                new SqlParameter("@Id",id)

           };
            if (await _sqlHelper.ExcuteDate(query, parameters) > 0)
            {

                return true;
            }
            else
            {
                return false;

            }
        }
    }
}
