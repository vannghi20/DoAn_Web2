using System;
using System.Threading.Tasks;
using ProjectWeb2.Models;

namespace ProjectWeb2.Interfaces
{
    public interface IContactLogic
    {
        Task<bool> CreatNewMess(ContacUs contact);
    }
}
