using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ProjectWeb2.Interfaces;
using ProjectWeb2.Models;

namespace ProjectWeb2.BussinessLogic
{
    public class ContactLogic:IContactLogic
    {
        private readonly ISqlHelper _sqlHelper;
        public ContactLogic(ISqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public async Task<bool> CreatNewMess(ContacUs contact)
        {
            string query = "insert into Contact (Name,Mail,Mess,Date,sdt) values (@Name,@Mail,@Mess,@Date,@sdt);";
            var parameters = new IDataParameter[]
            {
                new SqlParameter("@Name",contact.name),
                new SqlParameter("@Mail",contact.gmail),
                new SqlParameter("@Mess",contact.message),
                new SqlParameter("@Date",DateTime.Today),
                new SqlParameter("@sdt",contact.sdt)
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
