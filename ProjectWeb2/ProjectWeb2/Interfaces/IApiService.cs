using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWeb2.Interfaces
{
    public interface IApiService
    {
        Task<string> GetApi(string url);
    }
}
