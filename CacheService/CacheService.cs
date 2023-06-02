using System.Runtime.Serialization.Json;
using System.Text.Json;
using StackExchange.Redis;

namespace ChatApp.Services
{
    
    public class CacheService : ICachService
    {
        private IDatabase _dbcache;
        public CacheService()
        {
            ConnectionMultiplexer redis  =  ConnectionMultiplexer.Connect("");
            _dbcache = redis.GetDatabase();

        }
        public T getData<T>(string key)
        {
            var data =  _dbcache.StringGet(key);
            if (!string.IsNullOrEmpty(data)){
                return JsonSerializer.Deserialize<T>(data);
                }
            
            return default;
        }

        public object removeData(string Key)
        {
            bool _exist = _dbcache.KeyExists(Key);
            if (_exist){
                return _dbcache.KeyDelete(Key);
            }
            return false;
        }

        public async Task<bool> setData<T>(string key, T data)
        {
            
            bool isSet =  await _dbcache.StringSetAsync(key , JsonSerializer.Serialize<T>(data) );
            return isSet;



        }
    }
}