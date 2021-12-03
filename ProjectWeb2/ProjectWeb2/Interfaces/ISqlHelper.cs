using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb2.Interfaces
{
        public interface ISqlHelper
        {
            Task<DataTable> GetData(string str);
            Task<int> ExcuteDate(string str, params IDataParameter[] sqlParam);
        }
}
