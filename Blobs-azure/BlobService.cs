
using Azure.Storage;
using Azure.Storage.Blobs;

namespace ChatApp.Services
{
    public class BlobService : IBlobService
    {
        
        private readonly string _AccountName =""; //Storage account Name
        private readonly string key  = "";
      
        private BlobContainerClient _blobClient {get; set;}
        private readonly string _containerName = "";

        public BlobService(IConfiguration config)
        {
            
            StorageSharedKeyCredential x =  new StorageSharedKeyCredential(_AccountName , key);
            
            string blobUri = $"https://{_AccountName}.blob.core.windows.net";
            BlobServiceClient Client =  new BlobServiceClient(new Uri(blobUri) , x);
            _blobClient = Client.GetBlobContainerClient(this._containerName);



            
        } 
        public async Task<string> deleteasync(string name)
        {
            BlobClient blob = this._blobClient.GetBlobClient(name);
            
            
            if (await blob.ExistsAsync()){
                
                
                try{
                
                await blob.DeleteAsync();
                return "success";
                }
                catch{

                    return "exist but failed to delete";
                }

            
            }
            

            return "No file exist";
        }

        public async Task<string>  uploadasync(byte image, string name)
        {
            MemoryStream stream =  new MemoryStream(image);
            BlobClient blob  =this._blobClient.GetBlobClient(name);
            try{
                await blob.UploadAsync(stream);
                return blob.Uri.ToString();



        }catch{

            return string.Empty;


        }
        }
    }
}