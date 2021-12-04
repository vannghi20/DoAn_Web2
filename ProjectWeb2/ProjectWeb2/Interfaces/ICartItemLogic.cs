using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectWeb2.Models;

namespace ProjectWeb2.Interfaces
{
    public interface ICartItemLogic
    {
        Task<bool> CreateNewCart(CartItem cart);
        Task<List<CartItem>> GetAllCart();
        Task<bool> RemoveCart(int id);
        Task<bool> CreatNewOder(ListOder oder);
    }
}
