using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Services
{
    public interface ICachService
    {
        T getData<T>(string key);
        Task<bool> setData<T>(string key , T data);
        Object removeData(string Key);
    }
}