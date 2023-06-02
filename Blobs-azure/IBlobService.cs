
namespace ChatApp.Services
{
    public interface IBlobService
    {
        Task<string>  uploadasync(Byte image, string name);
        Task<string>  deleteasync(string name);

        
    }
}